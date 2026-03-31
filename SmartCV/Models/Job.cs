using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Job
{
    public long Id { get; set; }
    public long CompanyId { get; set; }

    [Required]
    public string Title { get; set; } = "";

    [MaxLength(255)]
    public string? Slug { get; set; }

    [Required]
    public string Description { get; set; } = "";

    public string? Responsibility { get; set; }
    public string? Skill { get; set; }
    public string? Education { get; set; }
    public string? Benefit { get; set; }

    [Required]
    public DateOnly Deadline { get; set; }

    public int Vacancy { get; set; }

    // Lookup FKs
    public long JobCategoryId { get; set; }
    public long JobLocationId { get; set; }
    public long JobTypeId { get; set; }
    public long JobExperienceId { get; set; }
    public long JobGenderId { get; set; }
    public long? JobSalaryRangeId { get; set; }

    public string? MapCode { get; set; }
    public bool IsFeatured { get; set; } = false;
    public bool IsUrgent { get; set; } = false;
    public int ViewCount { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Company Company { get; set; } = null!;
    public JobCategory JobCategory { get; set; } = null!;
    public JobLocation JobLocation { get; set; } = null!;
    public JobType JobType { get; set; } = null!;
    public JobExperience JobExperience { get; set; } = null!;
    public JobGender JobGender { get; set; } = null!;
    public JobSalaryRange? JobSalaryRange { get; set; }
    public ICollection<CandidateApplication> Applications { get; set; } = new List<CandidateApplication>();
    public ICollection<CandidateBookmark> Bookmarks { get; set; } = new List<CandidateBookmark>();
}
