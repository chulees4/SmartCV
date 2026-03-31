using System.ComponentModel.DataAnnotations;

namespace SmartCV.Models;

public class Candidate
{
    public long Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; } = "";

    [Required, MaxLength(255)]
    public string Email { get; set; } = "";

    [MaxLength(255)]
    public string? GoogleId { get; set; }

    [Required, MaxLength(255)]
    public string Password { get; set; } = "";

    [MaxLength(255)]
    public string? StudentId { get; set; }

    // AI Matching Foreign Keys
    public long? JobCategoryId { get; set; }
    public long? DesiredLocationId { get; set; }
    public long? DesiredExperienceId { get; set; }
    public long? DesiredSalaryRangeId { get; set; }

    [MaxLength(255)]
    public string? LectureId { get; set; }

    [MaxLength(255)]
    public string? Token { get; set; }

    [MaxLength(255)]
    public string? ResetToken { get; set; }

    [MaxLength(255)]
    public string? Photo { get; set; }

    public string? Biography { get; set; }

    [MaxLength(255)]
    public string? Phone { get; set; }

    [MaxLength(255)]
    public string? Country { get; set; }

    [MaxLength(255)]
    public string? Address { get; set; }

    [MaxLength(255)]
    public string? State { get; set; }

    [MaxLength(255)]
    public string? City { get; set; }

    [MaxLength(255)]
    public string? ZipCode { get; set; }

    [MaxLength(255)]
    public string? Gender { get; set; }

    [MaxLength(255)]
    public string? DateOfBirth { get; set; }

    [MaxLength(255)]
    public string? Website { get; set; }

    // 0=chưa verify, 1=active, 2=bị khóa, 3=import chưa đặt MK
    public byte Status { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public JobCategory? JobCategory { get; set; }
    public JobLocation? DesiredLocation { get; set; }
    public JobExperience? DesiredExperience { get; set; }
    public JobSalaryRange? DesiredSalaryRange { get; set; }
    public ICollection<CandidateEducation> Educations { get; set; } = new List<CandidateEducation>();
    public ICollection<CandidateSkill> Skills { get; set; } = new List<CandidateSkill>();
    public ICollection<CandidateExperience> Experiences { get; set; } = new List<CandidateExperience>();
    public ICollection<CandidateAward> Awards { get; set; } = new List<CandidateAward>();
    public ICollection<CandidateResume> Resumes { get; set; } = new List<CandidateResume>();
    public ICollection<CandidateBookmark> Bookmarks { get; set; } = new List<CandidateBookmark>();
    public ICollection<CandidateApplication> Applications { get; set; } = new List<CandidateApplication>();
    public ICollection<CandidateCv> GeneratedCvs { get; set; } = new List<CandidateCv>();
    public ICollection<JobAlert> JobAlerts { get; set; } = new List<JobAlert>();
}
