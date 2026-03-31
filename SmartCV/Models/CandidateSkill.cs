namespace SmartCV.Models;

public class CandidateSkill
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public string Name { get; set; } = "";
    public string Percentage { get; set; } = "";    // % thành thạo
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Candidate Candidate { get; set; } = null!;
}
