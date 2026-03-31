namespace SmartCV.Models;

public class CandidateBookmark
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public long JobId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Candidate Candidate { get; set; } = null!;
    public Job Job { get; set; } = null!;
}
