using Microsoft.EntityFrameworkCore;
using SmartCV.Data;
using SmartCV.Models;

namespace SmartCV.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // ─── Users ───────────────────────────────────────────────────────────────
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<Lecture> Lectures => Set<Lecture>();

    // ─── Job & Lookups ────────────────────────────────────────────────────────
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<JobCategory> JobCategories => Set<JobCategory>();
    public DbSet<JobLocation> JobLocations => Set<JobLocation>();
    public DbSet<JobType> JobTypes => Set<JobType>();
    public DbSet<JobExperience> JobExperiences => Set<JobExperience>();
    public DbSet<JobGender> JobGenders => Set<JobGender>();
    public DbSet<JobSalaryRange> JobSalaryRanges => Set<JobSalaryRange>();

    // ─── Candidate Profile ────────────────────────────────────────────────────
    public DbSet<CandidateEducation> CandidateEducations => Set<CandidateEducation>();
    public DbSet<CandidateSkill> CandidateSkills => Set<CandidateSkill>();
    public DbSet<CandidateExperience> CandidateExperiences => Set<CandidateExperience>();
    public DbSet<CandidateAward> CandidateAwards => Set<CandidateAward>();
    public DbSet<CandidateResume> CandidateResumes => Set<CandidateResume>();
    public DbSet<CandidateBookmark> CandidateBookmarks => Set<CandidateBookmark>();
    public DbSet<CandidateApplication> CandidateApplications => Set<CandidateApplication>();

    // ─── Company ─────────────────────────────────────────────────────────────
    public DbSet<CompanyLocation> CompanyLocations => Set<CompanyLocation>();
    public DbSet<CompanyIndustry> CompanyIndustries => Set<CompanyIndustry>();
    public DbSet<CompanySize> CompanySizes => Set<CompanySize>();
    public DbSet<CompanyPhoto> CompanyPhotos => Set<CompanyPhoto>();
    public DbSet<CompanyVideo> CompanyVideos => Set<CompanyVideo>();

    // ─── Content ─────────────────────────────────────────────────────────────
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Faq> Faqs => Set<Faq>();
    public DbSet<Testimonial> Testimonials => Set<Testimonial>();
    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<Advertisement> Advertisements => Set<Advertisement>();
    public DbSet<WhyChooseItem> WhyChooseItems => Set<WhyChooseItem>();
    public DbSet<Subscriber> Subscribers => Set<Subscriber>();

    // ─── CMS Pages ────────────────────────────────────────────────────────────
    public DbSet<PageHomeItem> PageHomeItems => Set<PageHomeItem>();
    public DbSet<PageBlogItem> PageBlogItems => Set<PageBlogItem>();
    public DbSet<PageFaqItem> PageFaqItems => Set<PageFaqItem>();
    public DbSet<PageTipItem> PageTipItems => Set<PageTipItem>();
    public DbSet<PageJobCategoryItem> PageJobCategoryItems => Set<PageJobCategoryItem>();
    public DbSet<PagePricingItem> PagePricingItems => Set<PagePricingItem>();
    public DbSet<PageContactItem> PageContactItems => Set<PageContactItem>();
    public DbSet<PageTermItem> PageTermItems => Set<PageTermItem>();
    public DbSet<PagePrivacyItem> PagePrivacyItems => Set<PagePrivacyItem>();
    public DbSet<PageOtherItem> PageOtherItems => Set<PageOtherItem>();

    // ─── Education ───────────────────────────────────────────────────────────
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Role> Roles => Set<Role>();

    // ─── CV Builder ──────────────────────────────────────────────────────────
    public DbSet<CvTemplate> CvTemplates => Set<CvTemplate>();
    public DbSet<CandidateCv> CandidateCvs => Set<CandidateCv>();

    // ─── Job Alert ───────────────────────────────────────────────────────────
    public DbSet<JobAlert> JobAlerts => Set<JobAlert>();

    // ─── System ──────────────────────────────────────────────────────────────
    public DbSet<Setting> Settings => Set<Setting>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ─── snake_case naming convention (PostgreSQL) ───────────────────────
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()!.ToSnakeCase());
            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());
            foreach (var key in entity.GetKeys())
                key.SetName(key.GetName()!.ToSnakeCase());
            foreach (var fk in entity.GetForeignKeys())
                fk.SetConstraintName(fk.GetConstraintName()!.ToSnakeCase());
            foreach (var idx in entity.GetIndexes())
                idx.SetDatabaseName(idx.GetDatabaseName()!.ToSnakeCase());
        }

        // ─── Unique Indexes ──────────────────────────────────────────────────
        modelBuilder.Entity<Admin>().HasIndex(a => a.Email).IsUnique();
        modelBuilder.Entity<Company>().HasIndex(c => c.Email).IsUnique();
        modelBuilder.Entity<Company>().HasIndex(c => c.GoogleId).IsUnique().HasFilter("google_id IS NOT NULL");
        modelBuilder.Entity<Candidate>().HasIndex(c => c.Email).IsUnique();
        modelBuilder.Entity<Candidate>().HasIndex(c => c.GoogleId).IsUnique().HasFilter("google_id IS NOT NULL");
        modelBuilder.Entity<Lecture>().HasIndex(l => l.Email).IsUnique();

        // ─── Job → Company / Lookups ─────────────────────────────────────────
        modelBuilder.Entity<Job>()
            .HasOne(j => j.Company).WithMany(c => c.Jobs).HasForeignKey(j => j.CompanyId);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobCategory).WithMany(c => c.Jobs).HasForeignKey(j => j.JobCategoryId);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobLocation).WithMany(l => l.Jobs).HasForeignKey(j => j.JobLocationId);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobType).WithMany(t => t.Jobs).HasForeignKey(j => j.JobTypeId);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobExperience).WithMany(e => e.Jobs).HasForeignKey(j => j.JobExperienceId);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobGender).WithMany(g => g.Jobs).HasForeignKey(j => j.JobGenderId);
        modelBuilder.Entity<Job>()
            .HasOne(j => j.JobSalaryRange).WithMany(s => s.Jobs).HasForeignKey(j => j.JobSalaryRangeId);

        // ─── Company → Lookups ───────────────────────────────────────────────
        modelBuilder.Entity<Company>()
            .HasOne(c => c.CompanyLocation).WithMany().HasForeignKey(c => c.CompanyLocationId);
        modelBuilder.Entity<Company>()
            .HasOne(c => c.CompanySize).WithMany().HasForeignKey(c => c.CompanySizeId);
        modelBuilder.Entity<Company>()
            .HasOne(c => c.CompanyIndustry).WithMany().HasForeignKey(c => c.CompanyIndustryId);

        // ─── CompanyPhoto / Video → Company ──────────────────────────────────
        modelBuilder.Entity<CompanyPhoto>()
            .HasOne(p => p.Company).WithMany(c => c.Photos).HasForeignKey(p => p.CompanyId);
        modelBuilder.Entity<CompanyVideo>()
            .HasOne(v => v.Company).WithMany(c => c.Videos).HasForeignKey(v => v.CompanyId);

        // ─── Candidate sub-tables ─────────────────────────────────────────────
        modelBuilder.Entity<CandidateEducation>()
            .HasOne(e => e.Candidate).WithMany(c => c.Educations).HasForeignKey(e => e.CandidateId);
        modelBuilder.Entity<CandidateSkill>()
            .HasOne(s => s.Candidate).WithMany(c => c.Skills).HasForeignKey(s => s.CandidateId);
        modelBuilder.Entity<CandidateExperience>()
            .HasOne(e => e.Candidate).WithMany(c => c.Experiences).HasForeignKey(e => e.CandidateId);
        modelBuilder.Entity<CandidateAward>()
            .HasOne(a => a.Candidate).WithMany(c => c.Awards).HasForeignKey(a => a.CandidateId);
        modelBuilder.Entity<CandidateResume>()
            .HasOne(r => r.Candidate).WithMany(c => c.Resumes).HasForeignKey(r => r.CandidateId);
        modelBuilder.Entity<CandidateBookmark>()
            .HasOne(b => b.Candidate).WithMany(c => c.Bookmarks).HasForeignKey(b => b.CandidateId);
        modelBuilder.Entity<CandidateBookmark>()
            .HasOne(b => b.Job).WithMany(j => j.Bookmarks).HasForeignKey(b => b.JobId);
        modelBuilder.Entity<CandidateApplication>()
            .HasOne(a => a.Candidate).WithMany(c => c.Applications).HasForeignKey(a => a.CandidateId);
        modelBuilder.Entity<CandidateApplication>()
            .HasOne(a => a.Job).WithMany(j => j.Applications).HasForeignKey(a => a.JobId);

        // ─── Candidate → AI Matching Lookups ─────────────────────────────────
        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.DesiredLocation).WithMany().HasForeignKey(c => c.DesiredLocationId);
        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.DesiredExperience).WithMany().HasForeignKey(c => c.DesiredExperienceId);
        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.DesiredSalaryRange).WithMany().HasForeignKey(c => c.DesiredSalaryRangeId);

        // ─── Education hierarchy ──────────────────────────────────────────────
        modelBuilder.Entity<JobCategory>()
            .HasOne(jc => jc.Faculty).WithMany(f => f.JobCategories).HasForeignKey(jc => jc.FacultyId);
        modelBuilder.Entity<Lecture>()
            .HasOne(l => l.Faculty).WithMany(f => f.Lectures).HasForeignKey(l => l.FacultyId);
        modelBuilder.Entity<Lecture>()
            .HasOne(l => l.Role).WithMany(r => r.Lectures).HasForeignKey(l => l.RoleId);

        // ─── Post → JobCategory ───────────────────────────────────────────────
        modelBuilder.Entity<Post>()
            .HasOne(p => p.JobCategory).WithMany(jc => jc.Posts).HasForeignKey(p => p.JobCategoryId);

        // ─── CV Builder ───────────────────────────────────────────────────────
        modelBuilder.Entity<CandidateCv>()
            .HasOne(cv => cv.Candidate).WithMany(c => c.GeneratedCvs).HasForeignKey(cv => cv.CandidateId);
        modelBuilder.Entity<CandidateCv>()
            .HasOne(cv => cv.CvTemplate).WithMany(t => t.CandidateCvs).HasForeignKey(cv => cv.CvTemplateId);

        // ─── Job Alert ────────────────────────────────────────────────────────
        modelBuilder.Entity<JobAlert>()
            .HasOne(ja => ja.Candidate).WithMany(c => c.JobAlerts).HasForeignKey(ja => ja.CandidateId);
        modelBuilder.Entity<JobAlert>()
            .HasOne(ja => ja.JobCategory).WithMany().HasForeignKey(ja => ja.JobCategoryId);
        modelBuilder.Entity<JobAlert>()
            .HasOne(ja => ja.JobLocation).WithMany().HasForeignKey(ja => ja.JobLocationId);
        modelBuilder.Entity<JobAlert>()
            .HasOne(ja => ja.JobType).WithMany().HasForeignKey(ja => ja.JobTypeId);
        modelBuilder.Entity<JobAlert>()
            .HasOne(ja => ja.JobSalaryRange).WithMany().HasForeignKey(ja => ja.JobSalaryRangeId);

        // ─── Seed Data ────────────────────────────────────────────────────────
        modelBuilder.Entity<Admin>().HasData(new Admin
        {
            Id = 1,
            Name = "Super Admin",
            Email = "admin@smartcv.com",
            Password = "$2a$11$91tVFkV2wtgQGhcqub4CFOg8vQM8o5z7vsxicUV7mMQLwcCFpEitC", // Admin@123
            Photo = "default.png",
            Token = ""
        });

        modelBuilder.Entity<Setting>().HasData(new Setting
        {
            Id = 1,
            TotalAllowedJob = 5,
            TotalAllowedFeaturedJob = 2,
            TotalAllowedPhoto = 5,
            TotalAllowedVideo = 3,
            Logo = "logo.png",
            Favicon = "favicon.png",
            CopyrightText = "© 2026 SmartCV"
        });

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Trưởng khoa" },
            new Role { Id = 2, Name = "Phó trưởng khoa" },
            new Role { Id = 3, Name = "Trưởng bộ môn" },
            new Role { Id = 4, Name = "Giảng viên" }
        );

        // Seed CMS pages với 1 bản ghi mặc định mỗi bảng
        modelBuilder.Entity<PageHomeItem>().HasData(new PageHomeItem
        {
            Id = 1, Heading = "Tìm Việc Làm Phù Hợp",
            Text = "Kết nối ứng viên & nhà tuyển dụng thông minh",
            Background = "", Title = "SmartCV - Nền tảng việc làm thông minh",
            MetaDiscription = "SmartCV - Kết nối sinh viên với nhà tuyển dụng"
        });
        modelBuilder.Entity<PageBlogItem>().HasData(new PageBlogItem { Id = 1, Heading = "Blog & Tin tức" });
        modelBuilder.Entity<PageFaqItem>().HasData(new PageFaqItem { Id = 1, Heading = "Câu hỏi thường gặp" });
        modelBuilder.Entity<PageTipItem>().HasData(new PageTipItem { Id = 1, Heading = "Mẹo tìm việc" });
        modelBuilder.Entity<PageJobCategoryItem>().HasData(new PageJobCategoryItem { Id = 1, Heading = "Danh mục việc làm" });
        modelBuilder.Entity<PagePricingItem>().HasData(new PagePricingItem { Id = 1, Heading = "Bảng giá" });
        modelBuilder.Entity<PageContactItem>().HasData(new PageContactItem { Id = 1, Heading = "Liên hệ", MapCode = "" });
        modelBuilder.Entity<PageTermItem>().HasData(new PageTermItem { Id = 1, Heading = "Điều khoản sử dụng", Content = "" });
        modelBuilder.Entity<PagePrivacyItem>().HasData(new PagePrivacyItem { Id = 1, Heading = "Chính sách bảo mật", Content = "" });
        modelBuilder.Entity<PageOtherItem>().HasData(new PageOtherItem
        {
            Id = 1,
            LoginPageHeading = "Đăng nhập",
            SignupPageHeading = "Đăng ký",
            ForgetPasswordPageHeading = "Quên mật khẩu",
            CompanyListingPageHeading = "Danh sách công ty",
            JobPageHeading = "Danh sách việc làm"
        });
        modelBuilder.Entity<Banner>().HasData(new Banner { Id = 1 });
        modelBuilder.Entity<Advertisement>().HasData(new Advertisement
        {
            Id = 1,
            JobListingAd = "", JobListingAdStatus = "0", JobListingAdUrl = "",
            CompanyListingAd = "", CompanyListingAdStatus = "0", CompanyListingAdUrl = ""
        });

        // Seed 3 mẫu CV mặc định
        modelBuilder.Entity<CvTemplate>().HasData(
            new CvTemplate { Id = 1, Name = "Mẫu Chuyên Nghiệp", TemplateHtml = "<!-- TODO: Template 1 HTML -->", TemplateCss = "", SortOrder = 1 },
            new CvTemplate { Id = 2, Name = "Mẫu Sáng Tạo", TemplateHtml = "<!-- TODO: Template 2 HTML -->", TemplateCss = "", SortOrder = 2 },
            new CvTemplate { Id = 3, Name = "Mẫu Đơn Giản", TemplateHtml = "<!-- TODO: Template 3 HTML -->", TemplateCss = "", SortOrder = 3 }
        );

        // Seed danh mục mẫu
        modelBuilder.Entity<JobType>().HasData(
            new JobType { Id = 1, Name = "Toàn thời gian" },
            new JobType { Id = 2, Name = "Bán thời gian" },
            new JobType { Id = 3, Name = "Thực tập" },
            new JobType { Id = 4, Name = "Freelance" },
            new JobType { Id = 5, Name = "Remote" }
        );
        modelBuilder.Entity<JobExperience>().HasData(
            new JobExperience { Id = 1, Name = "Không yêu cầu kinh nghiệm" },
            new JobExperience { Id = 2, Name = "Dưới 1 năm" },
            new JobExperience { Id = 3, Name = "1 - 2 năm" },
            new JobExperience { Id = 4, Name = "2 - 5 năm" },
            new JobExperience { Id = 5, Name = "Trên 5 năm" }
        );
        modelBuilder.Entity<JobGender>().HasData(
            new JobGender { Id = 1, Name = "Không yêu cầu" },
            new JobGender { Id = 2, Name = "Nam" },
            new JobGender { Id = 3, Name = "Nữ" }
        );
        modelBuilder.Entity<JobSalaryRange>().HasData(
            new JobSalaryRange { Id = 1, Name = "Thỏa thuận" },
            new JobSalaryRange { Id = 2, Name = "Dưới 5 triệu" },
            new JobSalaryRange { Id = 3, Name = "5 - 10 triệu" },
            new JobSalaryRange { Id = 4, Name = "10 - 20 triệu" },
            new JobSalaryRange { Id = 5, Name = "20 - 30 triệu" },
            new JobSalaryRange { Id = 6, Name = "Trên 30 triệu" }
        );
    }
}
