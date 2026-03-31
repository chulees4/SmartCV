namespace SmartCV.Models;

public class CandidateAward
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Date { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Candidate Candidate { get; set; } = null!;
}
