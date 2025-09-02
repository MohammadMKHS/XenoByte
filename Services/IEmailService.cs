namespace XenoByte.Services
{
    public interface IEmailService
    {
        Task SendPasswordResetEmailAsync(string toEmail, string resetToken, string baseUrl);
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}