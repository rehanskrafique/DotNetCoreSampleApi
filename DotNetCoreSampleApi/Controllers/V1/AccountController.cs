using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Enums;
using DotNetCoreSampleApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Controllers.V1
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/accounts/register")]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var apiResponse = await _accountService.RegisterAsync(registerDto);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/v1/accounts/token")]
        public async Task<IActionResult> Authenticate([FromBody] AuthDto authDto)
        {
            try
            {
                var apiResponse = await _accountService.AuthenticateAsync(authDto);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
            //var usersClaims = new[]
            //{
            //    new Claim(ClaimTypes.Name, user.UserName),
            //    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            //    new Claim("Name", user.Name),
            //    new Claim("EmailId", user.EmailId),
            //    new Claim("ContactNumber", user.ContactNumber),
            //    new Claim(ClaimTypes.Role, user.Role)
            //};

            //var accessToken = _tokenService.GenerateAccessToken(usersClaims);
            //var refreshToken = _tokenService.GenerateRefreshToken();

            //user.RefreshToken = refreshToken;
            //await _usersDb.SaveChangesAsync();

            //return new ObjectResult(new
            //{
            //    accessToken,
            //    refreshToken
            //});
        }

        [HttpPost]
        [Route("api/v1/accounts/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            try
            {
                var apiResponse = await _accountService.RefreshTokenAsync(refreshTokenDto);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }

        //[HttpPost]
        //[Route("api/v1/accounts/token/refresh_old")]
        //[HttpPost]
        //public async Task<IActionResult> RefreshToken_OLD([FromBody] RefreshTokenDto refreshTokenDto)
        //{
        //    var principal = _tokenService.GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken);
        //    Guid userId = Guid.Parse(principal.Identity.Name); //this is mapped to the Name claim by default

        //    var user = await _accountService.GetProfileAsync(userId);

        //    //if (user == null || user.RefreshToken != refreshTokenDto.RefreshToken)
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    };

        //    var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
        //    var newRefreshToken = _tokenService.GenerateRefreshToken();

        //    //user.RefreshToken = newRefreshToken;
        //    //await _usersDb.SaveChangesAsync();

        //    return new ObjectResult(new
        //    {
        //        accessToken = newAccessToken,
        //        refreshToken = newRefreshToken
        //    });
        //}

        [Authorize(Roles = "Customer")]
        [HttpGet]
        [Route("api/v1/accounts/claims")]
        public object Claims()
        {
            var userName = User.Identity.Name;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return User.Claims.Select(c => new { c.Type, c.Value });
        }
    }
}