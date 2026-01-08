using System.Collections.Generic;

namespace DataBaseLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public bool IsEmailVerified { get; set; }
        public string? EmailVerificationToken { get; set; }
        public DateTime? EmailVerificationExpiry { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordExpiry { get; set; }

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
        public ICollection<Label> Labels { get; set; } = new HashSet<Label>();
        public ICollection<Collaborator> CollaboratedNotes { get; set; } = new HashSet<Collaborator>();
    }
}
