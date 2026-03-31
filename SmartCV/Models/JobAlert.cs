using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class JobAlert
{
    public long Id { get; set; }
    public long CandidateId { get; set; }

    [MaxLength(255)]
    public string? AlertName { get; set; }

    public long? JobCategoryId { get; set; }
    public long? JobLocationId { get; set; }
    public long? JobTypeId { get; set; }
    public long? JobSalaryRangeId { get; set; }

    [MaxLength(500)]
    public string? Keywords { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime? LastSentAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Candidate Candidate { get; set; } = null!;
    public JobCategory? JobCategory { get; set; }
    public JobLocation? JobLocation { get; set; }
    public JobType? JobType { get; set; }
    public JobSalaryRange? JobSalaryRange { get; set; }
}
