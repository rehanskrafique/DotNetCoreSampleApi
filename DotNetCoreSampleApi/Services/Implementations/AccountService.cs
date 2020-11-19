using AutoMapper;
using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Data;
using DotNetCoreSampleApi.Domains;
using DotNetCoreSampleApi.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AccountService(AppDbContext context, IMapper mapper, ITokenService tokenService, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<ApiResponse> AuthenticateAsync(AuthDto authDto)
        {
            //Getting user by user name and password
            User user = await _context.Users.FirstOrDefaultAsync
                        (u => u.UserName == authDto.UserName && u.Password == authDto.Password);

            //Checking user has entered valid credentials or not
            if (user == null)
            {
                return new ApiResponse { Code = StatusCodes.NotFound, Message = "You entered invalid user name or password." };
            }

            #region Adding claims
            //Getting user roles
            var roles = from ur in _context.UserRoles
                        join r in _context.Roles on ur.RoleId equals r.RoleId
                        where ur.UserId == user.UserId
                        select new { ur.UserId, ur.RoleId, r.Name, r.NormalizedName };

            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Name, user.UserId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Expiration, user.UserId.ToString()),
                new Claim("Name", user.Name),
                new Claim("EmailId", user.EmailId),
                new Claim("ContactNumber", user.ContactNumber),



                new Claim(ClaimTypes.Expiration, _configuration["Jwt:AccessTokenExpiry"])
            };

            //Adding user role as a claim
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            #endregion

            #region Generating and saving refresh token
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            UserToken userToken = new UserToken
            {
                UserTokenId = Guid.NewGuid(),
                UserId = user.UserId,
                RefreshToken = refreshToken,
                IssuedOnUtc = DateTime.UtcNow,
                //ExpiresOnUtc = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:RefreshTokenExpiryInMinutes"])),
                ExpiresOnUtc = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration["Jwt:RefreshTokenExpiry"])),
                IPAddress = authDto.IPAddress,
                UserAgent = authDto.UserAgent
            };
            await _context.UserTokens.AddAsync(userToken);
            await _context.SaveChangesAsync();
            #endregion

            #region Returning response
            return new ApiResponse
            {
                Code = StatusCodes.Ok,
                Message = "Logged in successfully.",
                Result = new AuthResponseDto()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                }
            };

            #endregion
        }

        public async Task<ApiResponse> GetProfileAsync(Guid id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return new ApiResponse
            {
                Code = StatusCodes.NotFound,
                Message = "You entered invalid user name or password.",
                Result = _mapper.Map<UserDto>(user)
            };
        }

        public async Task<ApiResponse> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken);

            #region Validating access token
            if (principal == null)
            {
                return new ApiResponse { Code = StatusCodes.BadRequest, Message = "Invalid token." };
            }

            Guid userId = Guid.Parse(principal.Identity.Name);
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return new ApiResponse { Code = StatusCodes.BadRequest, Message = "Invalid user." };
            }

            //var accessTokenExpiry = DateTime.Parse(principal.Claims.Single(x => x.Type == ClaimTypes.Expiration).Value);

            //if (accessTokenExpiry > DateTime.UtcNow)
            //{
            //    return new ApiResponse { Code = StatusCodes.BadRequest, Message = "This token hasn't expired yet", Result = refreshTokenDto };
            //}

            var storedUserToken = await _context.UserTokens.FirstOrDefaultAsync(r => r.RefreshToken == refreshTokenDto.RefreshToken);

            if (storedUserToken == null)
            {
                return new ApiResponse { Code = StatusCodes.BadRequest, Message = "This refresh token does not exist." };
            }

            if (storedUserToken.Invalidated)
            {
                return new ApiResponse { Code = StatusCodes.BadRequest, Message = "This refresh token has been invalidated" };
            }

            if (storedUserToken.ExpiresOnUtc < DateTime.UtcNow)
            {
                return new ApiResponse { Code = StatusCodes.UnAuthorized, Message = "Refresh token has expired." };
            }
            #endregion

            #region Generating and saving refresh token
            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            UserToken userToken = new UserToken
            {
                UserTokenId = Guid.NewGuid(),
                UserId = userId,
                RefreshToken = newRefreshToken,
                IssuedOnUtc = DateTime.UtcNow,
                //ExpiresOnUtc = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:RefreshTokenExpiryInMinutes"])),
                ExpiresOnUtc = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration["Jwt:RefreshTokenExpiry"])),
                IPAddress = refreshTokenDto.IPAddress,
                UserAgent = refreshTokenDto.UserAgent
            };

            //Removing existing user token
            if (refreshTokenDto.RefreshToken.Equals(storedUserToken.RefreshToken))
            {
                _context.UserTokens.Remove(storedUserToken);
            }

            await _context.UserTokens.AddAsync(userToken);
            await _context.SaveChangesAsync();
            #endregion

            #region Returning response
            return new ApiResponse
            {
                Code = StatusCodes.Ok,
                Message = "Token refreshed successfully.",
                Result = new AuthResponseDto() { AccessToken = newAccessToken, RefreshToken = newRefreshToken }
            };
            #endregion
        }

        public async Task<ApiResponse> RegisterAsync(RegisterDto registerDto)
        {
            registerDto.Id = Guid.NewGuid();
            registerDto.UserId = registerDto.Id;
            User user = _mapper.Map<User>(registerDto);

            //Adding user
            await _context.Users.AddAsync(user);

            //Getting customer role
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.NormalizedName == "CUSTOMER");
            if (role == null)
            {
                throw new Exception("Seems customer role is not defined.");
            }
            //Adding user in customer role
            await _context.UserRoles.AddAsync(new UserRole { UserId = user.UserId, RoleId = role.RoleId });

            //Saving changes
            await _context.SaveChangesAsync();

            return new ApiResponse { Code = StatusCodes.Created, Message = "Registration successfully.", Result = registerDto };
        }
    }
}