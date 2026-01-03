using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Entities
{
    public class EmailOtp
    {
        public int EmailOtpId { get; set; }
        public string Email { get; set; } = string.Empty;
        public int OtpCodeHash { get; set; }
        public string Purpose { get; set; }= string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public int AttemptCount { get; set; }
        public DateTime CreatedAt { get; set; }

        //foreign key
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
