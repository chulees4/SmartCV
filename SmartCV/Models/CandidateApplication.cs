using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CandidateApplication
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public long JobId { get; set; }

    [Required]
    public string CoverLetter { get; set; } = "";

    // Applied → Approved / Rejected
    [Required, MaxLength(50)]
    public string Status { get; set; } = "Applied";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Candidate Candidate { get; set; } = null!;
    public Job Job { get; set; } = null!;
}
