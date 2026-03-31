namespace SmartCV.Models;

public class PageBlogItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PageFaqItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PageTipItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PageJobCategoryItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PagePricingItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PageContactItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string MapCode { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PageTermItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string Content { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PagePrivacyItem
{
    public long Id { get; set; }
    public string Heading { get; set; } = "";
    public string Content { get; set; } = "";
    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class PageOtherItem
{
    public long Id { get; set; }
    public string LoginPageHeading { get; set; } = "";
    public string? LoginPageTitle { get; set; }
    public string? LoginPageMetaDescription { get; set; }
    public string SignupPageHeading { get; set; } = "";
    public string? SignupPageTitle { get; set; }
    public string? SignupPageMetaDescription { get; set; }
    public string ForgetPasswordPageHeading { get; set; } = "";
    public string? ForgetPasswordPageTitle { get; set; }
    public string? ForgetPasswordPageMetaDescription { get; set; }
    public string CompanyListingPageHeading { get; set; } = "";
    public string? CompanyListingPageTitle { get; set; }
    public string? CompanyListingPageMetaDescription { get; set; }
    public string JobPageHeading { get; set; } = "";
    public string? JobPageTitle { get; set; }
    public string? JobPageMetaDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
