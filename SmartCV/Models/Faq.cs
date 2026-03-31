namespace SmartCV.Models;

public class Faq
{
    public long Id { get; set; }
    public string Question { get; set; } = "";
    public string Answer { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
