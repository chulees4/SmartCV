using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CompanyVideo
{
    public long Id { get; set; }

    public long CompanyId { get; set; }

    [Required, MaxLength(255)]
    public string VideoId { get; set; } = "";   // YouTube Video ID

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Company Company { get; set; } = null!;
}
