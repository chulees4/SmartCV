namespace SmartCV.Models;

public class Banner
{
    public long Id { get; set; }
    public string BannerJobListing { get; set; } = "";
    public string BannerJobDetail { get; set; } = "";
    public string BannerJobCategories { get; set; } = "";
    public string BannerCompanyListing { get; set; } = "";
    public string BannerCompanyDetail { get; set; } = "";
    public string BannerPricing { get; set; } = "";
    public string BannerBlog { get; set; } = "";
    public string BannerPost { get; set; } = "";
    public string BannerFaq { get; set; } = "";
    public string BannerContact { get; set; } = "";
    public string BannerTerms { get; set; } = "";
    public string BannerPrivacy { get; set; } = "";
    public string BannerSignup { get; set; } = "";
    public string BannerLogin { get; set; } = "";
    public string BannerForgetPassword { get; set; } = "";
    public string BannerCompanyPanel { get; set; } = "";
    public string BannerCandidatePanel { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
