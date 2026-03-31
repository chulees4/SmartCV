using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class JobCategory
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string Icon { get; set; } = "";

    public long? FacultyId { get; set; }
    public int? IsFeatured { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Faculty? Faculty { get; set; }
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
    public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
