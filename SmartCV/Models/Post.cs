using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Post
{
    public long Id { get; set; }

    [Required]
    public string Heading { get; set; } = "";

    [Required]
    public string Slug { get; set; } = "";

    [Required]
    public string ShortDescription { get; set; } = "";

    [Required]
    public string Description { get; set; } = "";

    [Required]
    public string TotalView { get; set; } = "0";

    [Required]
    public string Photo { get; set; } = "";

    public string? Title { get; set; }          // SEO
    public string? MetaDiscription { get; set; } // SEO

    public long? JobCategoryId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public JobCategory? JobCategory { get; set; }
}
