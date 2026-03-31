using Microsoft.EntityFrameworkCore;
using SmartCV.Data;
using SmartCV.Models;
using SmartCV.Services.Interfaces;
using SmartCV.ViewModels.Auth;

namespace SmartCV.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly IEmailService _email;

    public AuthService(AppDbContext db, IEmailService email)
    {
        _db = db;
        _email = email;
    }

    // ─── Candidate Register ─────────────────────────────────────────────────
    public async Task<(bool Success, string Message)> CandidateRegisterAsync(CandidateSignupViewModel model)
    {
        if (await _db.Candidates.AnyAsync(c => c.Email == model.Email))
            return (false, "Email này đã được đăng ký.");

        var token = Guid.NewGuid().ToString("N");
        var candidate = new Candidate
        {
            Name = model.Name,
            Email = model.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Token = token,
            Status = 0 // chưa verify
        };
        _db.Candidates.Add(candidate);
        await _db.SaveChangesAsync();

        await _email.SendWelcomeAsync(candidate.Email, candidate.Name, token, "candidate");
        return (true, "Đăng ký thành công! Vui lòng kiểm tra email để xác minh tài khoản.");
    }

    // ─── Candidate Email Verify ─────────────────────────────────────────────
    public async Task<(bool Success, string Message)> VerifyCandidateEmailAsync(string email, string token)
    {
        var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Email == email && c.Token == token);
        if (candidate is null)
            return (false, "Liên kết xác minh không hợp lệ hoặc đã hết hạn.");

        candidate.Status = 1;
        candidate.Token = null;
        candidate.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return (true, "Xác minh email thành công! Bạn có thể đăng nhập.");
    }

    // ─── Company Register ───────────────────────────────────────────────────
    public async Task<(bool Success, string Message)> CompanyRegisterAsync(CompanySignupViewModel model)
    {
        if (await _db.Companies.AnyAsync(c => c.Email == model.Email))
            return (false, "Email này đã được đăng ký.");

        var token = Guid.NewGuid().ToString("N");
        var company = new Company
        {
            CompanyName = model.CompanyName,
            Email = model.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Token = token,
            Status = 0 // chưa verify
        };
        _db.Companies.Add(company);
        await _db.SaveChangesAsync();

        await _email.SendWelcomeAsync(company.Email, company.CompanyName, token, "company");
        return (true, "Đăng ký thành công! Vui lòng kiểm tra email để xác minh tài khoản.");
    }

    // ─── Company Email Verify ───────────────────────────────────────────────
    public async Task<(bool Success, string Message)> VerifyCompanyEmailAsync(string email, string token)
    {
        var company = await _db.Companies.FirstOrDefaultAsync(c => c.Email == email && c.Token == token);
        if (company is null)
            return (false, "Liên kết xác minh không hợp lệ hoặc đã hết hạn.");

        company.Status = 1;
        company.Token = null;
        company.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return (true, "Xác minh email thành công! Bạn có thể đăng nhập.");
    }

    // ─── Forgot Password ────────────────────────────────────────────────────
    public async Task<(bool Success, string Message)> SendForgotPasswordEmailAsync(string email, string userType)
    {
        var token = Guid.NewGuid().ToString("N");
        var resetTime = DateTime.UtcNow;

        switch (userType.ToLower())
        {
            case "candidate":
            {
                var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Email == email);
                if (candidate is null) return (false, "Email không tồn tại trong hệ thống.");
                candidate.ResetToken = token;
                candidate.UpdatedAt = resetTime;
                break;
            }
            case "company":
            {
                var company = await _db.Companies.FirstOrDefaultAsync(c => c.Email == email);
                if (company is null) return (false, "Email không tồn tại trong hệ thống.");
                company.ResetToken = token;
                company.UpdatedAt = resetTime;
                break;
            }
            case "admin":
            {
                var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Email == email);
                if (admin is null) return (false, "Email không tồn tại trong hệ thống.");
                admin.Token = token;
                admin.UpdatedAt = resetTime;
                break;
            }
            case "lecture":
            {
                var lecture = await _db.Lectures.FirstOrDefaultAsync(l => l.Email == email);
                if (lecture is null) return (false, "Email không tồn tại trong hệ thống.");
                lecture.ResetToken = token;
                lecture.UpdatedAt = resetTime;
                break;
            }
            default:
                return (false, "Loại người dùng không hợp lệ.");
        }

        await _db.SaveChangesAsync();
        var name = userType switch { "candidate" => "Ứng viên", "company" => "Công ty", "admin" => "Admin", _ => "Giảng viên" };
        await _email.SendPasswordResetAsync(email, name, token, userType);
        return (true, "Đã gửi email đặt lại mật khẩu. Vui lòng kiểm tra hộp thư.");
    }

    // ─── Reset Password ─────────────────────────────────────────────────────
    public async Task<(bool Success, string Message)> ResetPasswordAsync(ResetPasswordViewModel model)
    {
        // Token hết hạn sau 60 phút — kiểm tra qua UpdatedAt
        var expiry = DateTime.UtcNow.AddMinutes(-60);

        switch (model.UserType.ToLower())
        {
            case "candidate":
            {
                var candidate = await _db.Candidates.FirstOrDefaultAsync(c =>
                    c.Email == model.Email && c.ResetToken == model.Token && c.UpdatedAt >= expiry);
                if (candidate is null) return (false, "Liên kết đặt lại mật khẩu không hợp lệ hoặc đã hết hạn.");
                candidate.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                candidate.ResetToken = null;
                candidate.UpdatedAt = DateTime.UtcNow;
                break;
            }
            case "company":
            {
                var company = await _db.Companies.FirstOrDefaultAsync(c =>
                    c.Email == model.Email && c.ResetToken == model.Token && c.UpdatedAt >= expiry);
                if (company is null) return (false, "Liên kết đặt lại mật khẩu không hợp lệ hoặc đã hết hạn.");
                company.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                company.ResetToken = null;
                company.UpdatedAt = DateTime.UtcNow;
                break;
            }
            case "admin":
            {
                var admin = await _db.Admins.FirstOrDefaultAsync(a =>
                    a.Email == model.Email && a.Token == model.Token && a.UpdatedAt >= expiry);
                if (admin is null) return (false, "Liên kết đặt lại mật khẩu không hợp lệ hoặc đã hết hạn.");
                admin.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                admin.Token = null;
                admin.UpdatedAt = DateTime.UtcNow;
                break;
            }
            case "lecture":
            {
                var lecture = await _db.Lectures.FirstOrDefaultAsync(l =>
                    l.Email == model.Email && l.ResetToken == model.Token && l.UpdatedAt >= expiry);
                if (lecture is null) return (false, "Liên kết đặt lại mật khẩu không hợp lệ hoặc đã hết hạn.");
                lecture.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                lecture.ResetToken = null;
                lecture.UpdatedAt = DateTime.UtcNow;
                break;
            }
            default:
                return (false, "Loại người dùng không hợp lệ.");
        }

        await _db.SaveChangesAsync();
        return (true, "Đặt lại mật khẩu thành công! Bạn có thể đăng nhập.");
    }

    // ─── Google OAuth ────────────────────────────────────────────────────────
    public async Task<Candidate?> FindOrCreateCandidateByGoogleAsync(string email, string name, string googleId)
    {
        var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.GoogleId == googleId || c.Email == email);
        if (candidate is not null)
        {
            // Cập nhật GoogleId nếu chưa có
            if (candidate.GoogleId != googleId)
            {
                candidate.GoogleId = googleId;
                candidate.UpdatedAt = DateTime.UtcNow;
                await _db.SaveChangesAsync();
            }
            return candidate;
        }

        // Tạo tài khoản mới qua Google — active ngay, password rỗng
        candidate = new Candidate
        {
            Name = name,
            Email = email,
            GoogleId = googleId,
            Password = "",
            Status = 1
        };
        _db.Candidates.Add(candidate);
        await _db.SaveChangesAsync();
        return candidate;
    }
}
