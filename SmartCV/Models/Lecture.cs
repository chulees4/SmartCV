using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Lecture
{
    public long Id { get; set; }

    public long? FacultyId { get; set; }

    // 1=Trưởng khoa, 2=Phó TK, 3=Trưởng bộ môn, 4=Giảng viên
    public long? RoleId { get; set; }

    public long? JobCategoryId { get; set; }

    [Required, MaxLength(255)]
    public string LectureCode { get; set; } = "";

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    [Required, MaxLength(255)]
    public string Phone { get; set; } = "";

    [Required, MaxLength(255)]
    public string Email { get; set; } = "";

    [Required, MaxLength(255)]
    public string Password { get; set; } = "";

    [MaxLength(255)]
    public string? Token { get; set; }

    [MaxLength(255)]
    public string? ResetToken { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Faculty? Faculty { get; set; }
    public Role? Role { get; set; }
    public JobCategory? JobCategory { get; set; }
}
