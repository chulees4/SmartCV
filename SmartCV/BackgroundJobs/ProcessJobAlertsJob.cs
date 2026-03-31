using SmartCV.Services.Interfaces;

namespace SmartCV.BackgroundJobs;

/// <summary>Hangfire recurring job — chạy 08:00 hàng ngày để gửi job alert.</summary>
public class ProcessJobAlertsJob
{
    private readonly IJobAlertService _alertService;

    public ProcessJobAlertsJob(IJobAlertService alertService)
    {
        _alertService = alertService;
    }

    // TODO Phase 7: Đăng ký thông qua Hangfire.RecurringJob.AddOrUpdate trong Program.cs
    public async Task ExecuteAsync()
    {
        await _alertService.ProcessAlertsAsync();
    }
}
