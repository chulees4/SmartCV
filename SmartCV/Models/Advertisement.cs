using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Advertisement
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string JobListingAd { get; set; } = "";
    [Required, MaxLength(255)]
    public string JobListingAdStatus { get; set; } = "";
    [Required, MaxLength(255)]
    public string JobListingAdUrl { get; set; } = "";

    [Required, MaxLength(255)]
    public string CompanyListingAd { get; set; } = "";
    [Required, MaxLength(255)]
    public string CompanyListingAdStatus { get; set; } = "";
    [Required, MaxLength(255)]
    public string CompanyListingAdUrl { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
