using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CandidateEducation
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public string Level { get; set; } = "";
    public string Institute { get; set; } = "";
    public string Degree { get; set; } = "";
    public string PassingYear { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Candidate Candidate { get; set; } = null!;
}
