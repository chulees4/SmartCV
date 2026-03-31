using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Company
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string CompanyName { get; set; } = "";

    [Required, MaxLength(255)]
    public string Email { get; set; } = "";

    [MaxLength(255)]
    public string? GoogleId { get; set; }

    [Required, MaxLength(255)]
    public string Password { get; set; } = "";

    [MaxLength(255)]
    public string? Token { get; set; }

    [MaxLength(255)]
    public string? ResetToken { get; set; }

    [MaxLength(255)]
    public string? Logo { get; set; }

    [MaxLength(255)]
    public string? Phone { get; set; }

    public string? Address { get; set; }

    // Foreign Keys — Lookups
    public long? CompanyLocationId { get; set; }
    public long? CompanySizeId { get; set; }
    public long? CompanyIndustryId { get; set; }

    [MaxLength(255)]
    public string? Website { get; set; }

    [MaxLength(255)]
    public string? FoundedOn { get; set; }

    public string? Description { get; set; }

    // Office Hours
    [MaxLength(255)] public string? OhMon { get; set; }
    [MaxLength(255)] public string? OhTue { get; set; }
    [MaxLength(255)] public string? OhWed { get; set; }
    [MaxLength(255)] public string? OhThu { get; set; }
    [MaxLength(255)] public string? OhFri { get; set; }
    [MaxLength(255)] public string? OhSat { get; set; }
    [MaxLength(255)] public string? OhSun { get; set; }

    public string? MapCode { get; set; }

    // Social Media
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }
    public string? Instagram { get; set; }

    // 0=chưa verify, 1=active, 2=bị khóa
    public byte Status { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public CompanyLocation? CompanyLocation { get; set; }
    public CompanySize? CompanySize { get; set; }
    public CompanyIndustry? CompanyIndustry { get; set; }
    public ICollection<CompanyPhoto> Photos { get; set; } = new List<CompanyPhoto>();
    public ICollection<CompanyVideo> Videos { get; set; } = new List<CompanyVideo>();
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
