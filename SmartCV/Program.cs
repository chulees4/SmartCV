using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartCV.Data;
using SmartCV.Services;
using SmartCV.Services.Interfaces;
using System.Globalization;

// ─── Serilog ────────────────────────────────────────────────────────────────
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/smartcv-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// ─── 1. Configuration Binding ────────────────────────────────────────────────
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.Configure<FileUploadSettings>(builder.Configuration.GetSection("FileUpload"));

// ─── 2. Database (EF Core + PostgreSQL) ─────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)));

// ─── 3. Authentication (Cookie Multi-Scheme) ────────────────────────────────
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "CandidateScheme";
})
.AddCookie("AdminScheme", o =>
{
    o.LoginPath = "/Admin/Auth/Login";
    o.AccessDeniedPath = "/Admin/Auth/AccessDenied";
    o.ExpireTimeSpan = TimeSpan.FromHours(8);
    o.SlidingExpiration = true;
})
.AddCookie("CompanyScheme", o =>
{
    o.LoginPath = "/Auth/Login";
    o.AccessDeniedPath = "/Auth/AccessDenied";
    o.ExpireTimeSpan = TimeSpan.FromHours(8);
    o.SlidingExpiration = true;
})
.AddCookie("CandidateScheme", o =>
{
    o.LoginPath = "/Auth/Login";
    o.AccessDeniedPath = "/Auth/AccessDenied";
    o.ExpireTimeSpan = TimeSpan.FromDays(7);
    o.SlidingExpiration = true;
})
.AddCookie("LectureScheme", o =>
{
    o.LoginPath = "/Auth/LectureLogin";
    o.AccessDeniedPath = "/Auth/AccessDenied";
    o.ExpireTimeSpan = TimeSpan.FromHours(8);
})
.AddGoogle("Google", o =>
{
    o.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    o.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    o.SignInScheme = "CandidateScheme";
});

// ─── 4. Authorization Policies ──────────────────────────────────────────────
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p =>
        p.AddAuthenticationSchemes("AdminScheme").RequireAuthenticatedUser().RequireRole("Admin"));
    options.AddPolicy("CompanyOnly", p =>
        p.AddAuthenticationSchemes("CompanyScheme").RequireAuthenticatedUser().RequireRole("Company"));
    options.AddPolicy("CandidateOnly", p =>
        p.AddAuthenticationSchemes("CandidateScheme").RequireAuthenticatedUser().RequireRole("Candidate"));
    options.AddPolicy("LectureOnly", p =>
        p.AddAuthenticationSchemes("LectureScheme").RequireAuthenticatedUser().RequireRole("Lecture"));

    // Lecture sub-roles (1=Trưởng khoa, 2=Trưởng bộ môn, 3=Giảng viên, 4=Trợ giảng)
    options.AddPolicy("DeanOnly", p =>
        p.AddAuthenticationSchemes("LectureScheme").RequireClaim("LectureRole", "1"));
    options.AddPolicy("DeanCommittee", p =>
        p.AddAuthenticationSchemes("LectureScheme").RequireClaim("LectureRole", "1", "2"));
    options.AddPolicy("LeaderUp", p =>
        p.AddAuthenticationSchemes("LectureScheme").RequireClaim("LectureRole", "1", "2", "3"));
});

// ─── 5. Services (DI) ───────────────────────────────────────────────────────
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IChatbotService, ChatbotService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IImportExportService, ImportExportService>();
builder.Services.AddScoped<IJobMatchingService, JobMatchingService>();
builder.Services.AddScoped<ICvBuilderService, CvBuilderService>();
builder.Services.AddScoped<IJobAlertService, JobAlertService>();

// ─── 6. MVC + Localization ──────────────────────────────────────────────────
builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

// ─── 7. Hangfire ────────────────────────────────────────────────────────────
// TODO Phase 7: Uncomment sau khi DB đã chạy
// builder.Services.AddHangfire(config =>
//     config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddHangfireServer();

// ─── 8. Caching & Session ───────────────────────────────────────────────────
builder.Services.AddMemoryCache();
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromMinutes(120);
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

// ════════════════════════════════════════════════════════════════════════════
var app = builder.Build();
// ════════════════════════════════════════════════════════════════════════════

// ─── Middleware Pipeline ─────────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Localization (vi-VN default)
var supportedCultures = new[] { new CultureInfo("vi-VN"), new CultureInfo("en-US") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("vi-VN"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders =
    [
        new CookieRequestCultureProvider(),
        new QueryStringRequestCultureProvider()
    ]
});

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// TODO Phase 7: Uncomment sau khi Hangfire được kích hoạt
// app.UseHangfireDashboard("/admin/hangfire");
// RecurringJob.AddOrUpdate<ProcessJobAlertsJob>("job-alerts", j => j.ExecuteAsync(), "0 8 * * *");

// ─── Routing ─────────────────────────────────────────────────────────────────
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
