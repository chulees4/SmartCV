using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class JobType
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
