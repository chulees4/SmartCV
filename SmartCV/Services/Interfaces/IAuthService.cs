using SmartCV.ViewModels.Auth;

namespace SmartCV.Services.Interfaces;

public interface IAuthService
{
    // ─── Candidate ──────────────────────────────────────────────────────────
    Task<(bool Success, string Message)> CandidateRegisterAsync(CandidateSignupViewModel model);
    Task<(bool Success, string Message)> VerifyCandidateEmailAsync(string email, string token);

    // ─── Company ────────────────────────────────────────────────────────────
    Task<(bool Success, string Message)> CompanyRegisterAsync(CompanySignupViewModel model);
    Task<(bool Success, string Message)> VerifyCompanyEmailAsync(string email, string token);

    // ─── Forgot / Reset Password (Candidate, Company, Admin, Lecture) ──────
    Task<(bool Success, string Message)> SendForgotPasswordEmailAsync(string email, string userType);
    Task<(bool Success, string Message)> ResetPasswordAsync(ResetPasswordViewModel model);

    // ─── Google OAuth (Candidate only) ──────────────────────────────────────
    Task<SmartCV.Models.Candidate?> FindOrCreateCandidateByGoogleAsync(string email, string name, string googleId);
}
