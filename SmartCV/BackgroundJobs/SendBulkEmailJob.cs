using SmartCV.Services.Interfaces;

namespace SmartCV.BackgroundJobs;

/// <summary>Hangfire job — gửi hàng loạt email theo danh sách.</summary>
public class SendBulkEmailJob
{
    private readonly IEmailService _emailService;

    public SendBulkEmailJob(IEmailService emailService)
    {
        _emailService = emailService;
    }

    // TODO Phase 7: Implement bulk send
    public Task ExecuteAsync(List<(string Email, string Name)> recipients, string subject, string htmlBody)
        => throw new NotImplementedException();
}
