using MailKit.Net.Smtp;
using MimeKit;

namespace FundooNotes.Helpers
{
    public class OtpEmailSender
    {
        private readonly IConfiguration _config;

        public OtpEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendOtpAsync(string toEmail, string otp)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["Smtp:User"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Your OTP Verification Code";
            email.Body = new TextPart("plain")
            {
                Text = $"Your OTP is: {otp}"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                _config["Smtp:Host"],
                int.Parse(_config["Smtp:Port"]!),
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _config["Smtp:User"],
                _config["Smtp:Password"]);

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
