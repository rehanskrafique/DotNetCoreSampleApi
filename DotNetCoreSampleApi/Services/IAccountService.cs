using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Domains;
using System;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Services
{
    public interface IAccountService
    {
        Task<ApiResponse> RegisterAsync(RegisterDto registerDto);

        Task<ApiResponse> AuthenticateAsync(AuthDto authDto);

        Task<ApiResponse> GetProfileAsync(Guid id);

        Task<ApiResponse> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    }
}