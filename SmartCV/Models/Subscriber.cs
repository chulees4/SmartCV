namespace SmartCV.Models;

public class Subscriber
{
    public long Id { get; set; }
    public string Email { get; set; } = "";
    public string Token { get; set; } = "";
    public byte Status { get; set; } = 0;   // 0=inactive, 1=active
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
