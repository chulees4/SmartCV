namespace SmartCV.Models;

/// <summary>Cấu hình trang chủ — chỉ có 1 bản ghi duy nhất.</summary>
public class PageHomeItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string? Text { get; set; }
    public string JobTitle { get; set; } = "Job Title";
    public string JobCategory { get; set; } = "Job Category";
    public string JobLocation { get; set; } = "Job Location";
    public string Search { get; set; } = "Search";
    public string Background { get; set; } = "";
    public string JobCategoryHeading { get; set; } = "";
    public string? JobCategorySubheading { get; set; }
    public string JobCategoryStatus { get; set; } = "1";
    public string WhyChooseHeading { get; set; } = "";
    public string? WhyChooseSubheading { get; set; }
    public string WhyChooseStatus { get; set; } = "1";
    public string WhyChooseBackground { get; set; } = "";
    public string FeaturedJobHeading { get; set; } = "";
    public string? FeaturedJobSubheading { get; set; }
    public string FeaturedJobStatus { get; set; } = "1";
    public string TestimonialHeading { get; set; } = "";
    public string TestimonialBackground { get; set; } = "";
    public string TestimonialStatus { get; set; } = "1";
    public string BlogHeading { get; set; } = "";
    public string? BlogSubheading { get; set; }
    public string BlogStatus { get; set; } = "1";
    public string Title { get; set; } = "";
    public string MetaDiscription { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
