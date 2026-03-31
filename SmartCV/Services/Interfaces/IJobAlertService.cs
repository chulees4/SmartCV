namespace SmartCV.Services.Interfaces;

public interface IJobAlertService
{
    /// <summary>Quét tất cả alert đang bật và gửi email thông báo việc làm mới.</summary>
    Task ProcessAlertsAsync();
}
