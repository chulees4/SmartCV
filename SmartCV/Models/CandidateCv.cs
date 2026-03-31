using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CandidateCv
{
    public long Id { get; set; }
    public long CandidateId { get; set; }
    public long CvTemplateId { get; set; }

    [Required, MaxLength(255)]
    public string Title { get; set; } = "";

    public string? GeneratedHtml { get; set; }

    [MaxLength(255)]
    public string? PdfPath { get; set; }

    [MaxLength(20)]
    public string? CustomColor { get; set; }

    [MaxLength(100)]
    public string? CustomFont { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Candidate Candidate { get; set; } = null!;
    public CvTemplate CvTemplate { get; set; } = null!;
}
