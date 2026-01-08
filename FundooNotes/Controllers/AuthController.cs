using BusinessLayer.Interfaces.Services;
using FundooNotes.Helpers;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs.Auth;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtTokenGenerator _jwt;
        private readonly OtpEmailSender _otpSender;

        public AuthController(
            IAuthService authService,
            JwtTokenGenerator jwt,
            OtpEmailSender otpSender)
        {
            _authService = authService;
            _jwt = jwt;
            _otpSender = otpSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var otp = await _authService.RegisterAsync(dto);
            try
            {
                await _otpSender.SendOtpAsync(dto.Email, otp);
            }
            catch (Exception ex)
            {
                // Log error but do NOT fail registration
                Results.StatusCode(500);
            }


            return Ok(new
            {
                message = "OTP sent to email"
            });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto dto)
        {
            await _authService.VerifyOtpAsync(dto.Email, dto.Otp);
            return Ok(new { message = "Email verified successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            var token = _jwt.GenerateToken(result.UserId, result.Email);

            return Ok(new
            {
                token,
                expiresIn = 3600
            });
        }
    }
}
