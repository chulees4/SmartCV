namespace SmartCV.Models;

/// <summary>Cài đặt toàn hệ thống — chỉ có 1 bản ghi duy nhất (Id = 1).</summary>
public class Setting
{
    public long Id { get; set; }

    // Quota mặc định cho Company
    public int TotalAllowedJob { get; set; } = 5;
    public int TotalAllowedFeaturedJob { get; set; } = 2;
    public int TotalAllowedPhoto { get; set; } = 5;
    public int TotalAllowedVideo { get; set; } = 3;

    public string Logo { get; set; } = "logo.png";
    public string Favicon { get; set; } = "favicon.png";

    public string? TopBarPhone { get; set; }
    public string? TopBarEmail { get; set; }
    public string? FooterPhone { get; set; }
    public string? FooterEmail { get; set; }
    public string? FooterAddress { get; set; }

    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }
    public string? Pinterest { get; set; }
    public string? Instagram { get; set; }

    public string CopyrightText { get; set; } = "© 2026 SmartCV";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
