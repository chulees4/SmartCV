using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CompanyIndustry
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
