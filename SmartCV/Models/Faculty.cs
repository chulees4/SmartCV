using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Faculty
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    [MaxLength(255)]
    public string? Logo { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public ICollection<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
