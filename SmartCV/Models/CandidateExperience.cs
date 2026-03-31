namespace SmartCV.Models;

public class CandidateExperience
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public string Company { get; set; } = "";
    public string Designation { get; set; } = "";
    public string StartDate { get; set; } = "";
    public string EndDate { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Candidate Candidate { get; set; } = null!;
}
