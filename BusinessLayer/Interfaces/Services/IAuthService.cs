using ModelLayer.DTOs.Auth;

namespace BusinessLayer.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterRequestDto dto);
        Task VerifyOtpAsync(string email, string otp);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);
    }
}
