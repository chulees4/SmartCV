using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class CvTemplate
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    public string TemplateHtml { get; set; } = "";  // HTML với placeholders {{Name}}, {{Skills}}...
    public string TemplateCss { get; set; } = "";

    [MaxLength(255)]
    public string? ThumbnailPath { get; set; }

    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<CandidateCv> CandidateCvs { get; set; } = new List<CandidateCv>();
}
