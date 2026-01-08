using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Rules;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs.Auth;

namespace BusinessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RegisterAsync(RegisterRequestDto dto)
        {
            UserRules.ValidateRegistration(dto);

            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new ValidationException("User already exists");

            var otp = GenerateOtp();

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                EmailVerificationToken = otp,
                EmailVerificationExpiry = DateTime.UtcNow.AddMinutes(10),
                IsEmailVerified = false
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return otp;
        }

        public async Task VerifyOtpAsync(string email, string otp)
        {
            var user = await _userRepository.GetByEmailAsync(email)
                ?? throw new NotFoundException("User not found");

            if (user.EmailVerificationToken != otp ||
                user.EmailVerificationExpiry < DateTime.UtcNow)
            {
                throw new ValidationException("Invalid or expired OTP");
            }

            user.IsEmailVerified = true;
            user.EmailVerificationToken = null;
            user.EmailVerificationExpiry = null;

            await _userRepository.SaveAsync();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email)
                ?? throw new UnauthorizedException("Invalid credentials");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedException("Invalid credentials");

            if (!user.IsEmailVerified)
                throw new UnauthorizedException("Email not verified");

            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email
            };
        }

        private static string GenerateOtp()
        {
            return new Random().Next(100000, 999999).ToString();
        }
    }
}
