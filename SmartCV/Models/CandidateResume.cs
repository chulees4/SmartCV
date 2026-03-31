namespace SmartCV.Models;

public class CandidateResume
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public string Name { get; set; } = "";
    public string File { get; set; } = "";          // Đường dẫn file PDF/DOCX
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Candidate Candidate { get; set; } = null!;
}
