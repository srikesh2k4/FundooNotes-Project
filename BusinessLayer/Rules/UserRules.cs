using BusinessLayer.Exceptions;
using ModelLayer.DTOs.Auth;

namespace BusinessLayer.Rules
{
    public static class UserRules
    {
        public static void ValidateRegistration(RegisterRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ValidationException("Name is required");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ValidationException("Email is required");

            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
                throw new ValidationException("Password must be at least 6 characters");
        }
    }
}
