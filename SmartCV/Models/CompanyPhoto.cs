using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CompanyPhoto
{
    public long Id { get; set; }

    public long CompanyId { get; set; }

    [Required, MaxLength(255)]
    public string Photo { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Company Company { get; set; } = null!;
}
