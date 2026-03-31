using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SmartCV.Services.Interfaces;

namespace SmartCV.Services;

public class SmtpSettings
{
    public string Host { get; set; } = "";
    public int Port { get; set; }
    public bool UseSsl { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string FromEmail { get; set; } = "";
    public string FromName { get; set; } = "";
}

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtp;

    public EmailService(IOptions<SmtpSettings> smtp)
    {
        _smtp = smtp.Value;
    }

    public async Task SendAsync(string toEmail, string toName, string subject, string htmlBody)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_smtp.FromName, _smtp.FromEmail));
        message.To.Add(new MailboxAddress(toName, toEmail));
        message.Subject = subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlBody };

        using var client = new SmtpClient();
        await client.ConnectAsync(_smtp.Host, _smtp.Port,
            _smtp.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None);
        await client.AuthenticateAsync(_smtp.Username, _smtp.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    public Task SendWelcomeAsync(string toEmail, string toName)
        => SendAsync(toEmail, toName, "Chào mừng đến với SmartCV",
            $"<h2>Xin chào {toName}!</h2><p>Tài khoản SmartCV của bạn đã được tạo thành công.</p>");

    public Task SendPasswordResetAsync(string toEmail, string toName, string resetToken)
        => SendAsync(toEmail, toName, "Đặt lại mật khẩu SmartCV",
            $"<p>Xin chào {toName},</p><p>Click vào link bên dưới để đặt lại mật khẩu (hết hạn sau 30 phút):</p>" +
            $"<a href='/Auth/ResetPassword?token={resetToken}'>Đặt lại mật khẩu</a>");

    public Task SendApplicationNotifyCompanyAsync(string toEmail, string companyName, string applicantName, string jobTitle)
        => SendAsync(toEmail, companyName, $"Ứng viên mới cho vị trí {jobTitle}",
            $"<p>Công ty <b>{companyName}</b> có ứng viên mới: <b>{applicantName}</b> vừa ứng tuyển vào <b>{jobTitle}</b>.</p>");

    public Task SendApplicationStatusAsync(string toEmail, string candidateName, string jobTitle, string status)
        => SendAsync(toEmail, candidateName, $"Cập nhật đơn ứng tuyển — {jobTitle}",
            $"<p>Xin chào <b>{candidateName}</b>,</p><p>Đơn ứng tuyển của bạn cho vị trí <b>{jobTitle}</b> đã được cập nhật: <b>{status}</b>.</p>");

    public Task SendJobAlertAsync(string toEmail, string candidateName, List<string> jobTitles)
    {
        var list = string.Join("", jobTitles.Select(j => $"<li>{j}</li>"));
        return SendAsync(toEmail, candidateName, "Việc làm mới phù hợp với bạn",
            $"<p>Xin chào <b>{candidateName}</b>,</p><p>Có {jobTitles.Count} việc làm mới phù hợp với cảnh báo của bạn:</p><ul>{list}</ul>");
    }
}
