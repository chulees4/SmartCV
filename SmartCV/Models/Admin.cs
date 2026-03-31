using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Admin
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    [Required, MaxLength(255)]
    public string Email { get; set; } = "";

    [Required, MaxLength(255)]
    public string Password { get; set; } = "";

    [MaxLength(255)]
    public string Photo { get; set; } = "default.png";

    [MaxLength(255)]
    public string? Token { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
