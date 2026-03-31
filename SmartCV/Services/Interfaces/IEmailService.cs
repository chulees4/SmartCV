namespace SmartCV.Services.Interfaces;

public interface IEmailService
{
    Task SendAsync(string toEmail, string toName, string subject, string htmlBody);
    Task SendWelcomeAsync(string toEmail, string toName, string token, string userType);
    Task SendPasswordResetAsync(string toEmail, string toName, string resetToken, string userType);
    Task SendApplicationNotifyCompanyAsync(string toEmail, string companyName, string applicantName, string jobTitle);
    Task SendApplicationStatusAsync(string toEmail, string candidateName, string jobTitle, string status);
    Task SendJobAlertAsync(string toEmail, string candidateName, List<string> jobTitles);
}
