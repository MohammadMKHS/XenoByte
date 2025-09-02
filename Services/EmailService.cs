using System.Net;
using System.Net.Mail;

namespace XenoByte.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendPasswordResetEmailAsync(string toEmail, string resetToken, string baseUrl)
        {
            var resetLink = $"{baseUrl}/Authentication/ResetPassword?token={resetToken}";
            
            var subject = "XenoByte - Password Reset Request";
            var body = $@"
                <html>
                <body style='font-family: Arial, sans-serif; background-color: #1a1a1a; color: #ffffff; padding: 20px;'>
                    <div style='max-width: 600px; margin: 0 auto; background-color: #2a2a2a; padding: 30px; border-radius: 10px; border: 1px solid #00f5d4;'>
                        <div style='text-align: center; margin-bottom: 30px;'>
                            <h1 style='color: #00f5d4; margin: 0;'>XenoByte</h1>
                            <p style='color: #888; margin: 5px 0;'>Blockchain Forensics & Cyber Threat Intelligence</p>
                        </div>
                        
                        <h2 style='color: #ffffff; border-bottom: 2px solid #00f5d4; padding-bottom: 10px;'>Password Reset Request</h2>
                        
                        <p>Hello,</p>
                        
                        <p>We received a request to reset your password for your XenoByte account. If you made this request, please click the button below to reset your password:</p>
                        
                        <div style='text-align: center; margin: 30px 0;'>
                            <a href='{resetLink}' style='background-color: #00f5d4; color: #1a1a1a; padding: 15px 30px; text-decoration: none; border-radius: 5px; font-weight: bold; display: inline-block;'>Reset Password</a>
                        </div>
                        
                        <p>Or copy and paste this link into your browser:</p>
                        <p style='background-color: #333; padding: 10px; border-radius: 5px; word-break: break-all; font-family: monospace; font-size: 12px;'>{resetLink}</p>
                        
                        <p><strong>Important:</strong> This link will expire in 1 hour for security reasons.</p>
                        
                        <p>If you did not request a password reset, please ignore this email. Your password will remain unchanged.</p>
                        
                        <hr style='border: 1px solid #444; margin: 30px 0;'>
                        
                        <p style='color: #888; font-size: 12px; text-align: center;'>
                            This is an automated message from XenoByte Security Team.<br>
                            © 2025 XenoByte. All rights reserved.
                        </p>
                    </div>
                </body>
                </html>";

            await SendEmailAsync(toEmail, subject, body);
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            var senderEmail = _configuration["EmailSettings:SenderEmail"];
            var senderPassword = _configuration["EmailSettings:SenderPassword"];
            var senderName = _configuration["EmailSettings:SenderName"];

            using var client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}