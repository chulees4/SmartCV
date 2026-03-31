namespace SmartCV.Models;

public class Testimonial
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Designation { get; set; } = "";
    public string Photo { get; set; } = "";
    public string Comment { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
