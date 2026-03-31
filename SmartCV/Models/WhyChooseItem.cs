namespace SmartCV.Models;

public class WhyChooseItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string Icon { get; set; } = "";
    public string Text { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
