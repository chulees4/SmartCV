using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCV.Data;
using SmartCV.Services.Interfaces;
using SmartCV.ViewModels.Auth;
using System.Security.Claims;

namespace SmartCV.Controllers;

public class AuthController : Controller
{
    private readonly AppDbContext _db;
    private readonly IAuthService _auth;

    public AuthController(AppDbContext db, IAuthService auth)
    {
        _db = db;
        _auth = auth;
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /login — Trang đăng nhập chung (Candidate + Company)
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/login")]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View(new LoginViewModel());
    }

    // ════════════════════════════════════════════════════════════════════════
    // POST /candidate-login-submit
    // ════════════════════════════════════════════════════════════════════════
    [HttpPost("/candidate-login-submit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CandidateLogin(LoginViewModel model, string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        if (!ModelState.IsValid)
        {
            TempData["LoginTab"] = "candidate";
            return View("Login", model);
        }

        var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Email == model.Email);
        if (candidate is null || !BCrypt.Net.BCrypt.Verify(model.Password, candidate.Password))
        {
            TempData["Error"] = "Email hoặc mật khẩu không đúng.";
            TempData["LoginTab"] = "candidate";
            return View("Login", model);
        }
        if (candidate.Status == 0)
        {
            TempData["Error"] = "Tài khoản chưa xác minh email. Vui lòng kiểm tra hộp thư.";
            TempData["LoginTab"] = "candidate";
            return View("Login", model);
        }
        if (candidate.Status == 2)
        {
            TempData["Error"] = "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.";
            TempData["LoginTab"] = "candidate";
            return View("Login", model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, candidate.Id.ToString()),
            new(ClaimTypes.Name, candidate.Name),
            new(ClaimTypes.Email, candidate.Email),
            new(ClaimTypes.Role, "Candidate"),
            new("Photo", candidate.Photo ?? "default.png")
        };
        var identity = new ClaimsIdentity(claims, "CandidateScheme");
        var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
        await HttpContext.SignInAsync("CandidateScheme", new ClaimsPrincipal(identity), props);

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        return RedirectToAction("Index", "Dashboard", new { area = "Candidate" });
    }

    // ════════════════════════════════════════════════════════════════════════
    // POST /company-login-submit
    // ════════════════════════════════════════════════════════════════════════
    [HttpPost("/company-login-submit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CompanyLogin(LoginViewModel model, string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        if (!ModelState.IsValid)
        {
            TempData["LoginTab"] = "company";
            return View("Login", model);
        }

        var company = await _db.Companies.FirstOrDefaultAsync(c => c.Email == model.Email);
        if (company is null || !BCrypt.Net.BCrypt.Verify(model.Password, company.Password))
        {
            TempData["Error"] = "Email hoặc mật khẩu không đúng.";
            TempData["LoginTab"] = "company";
            return View("Login", model);
        }
        if (company.Status == 0)
        {
            TempData["Error"] = "Tài khoản chưa xác minh email. Vui lòng kiểm tra hộp thư.";
            TempData["LoginTab"] = "company";
            return View("Login", model);
        }
        if (company.Status == 2)
        {
            TempData["Error"] = "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.";
            TempData["LoginTab"] = "company";
            return View("Login", model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, company.Id.ToString()),
            new(ClaimTypes.Name, company.CompanyName),
            new(ClaimTypes.Email, company.Email),
            new(ClaimTypes.Role, "Company"),
            new("Photo", company.Logo ?? "default.png")
        };
        var identity = new ClaimsIdentity(claims, "CompanyScheme");
        var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
        await HttpContext.SignInAsync("CompanyScheme", new ClaimsPrincipal(identity), props);

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        return RedirectToAction("Index", "Dashboard", new { area = "Company" });
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /create-account — Trang đăng ký
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/create-account")]
    public IActionResult Signup()
    {
        ViewBag.CandidateModel = new CandidateSignupViewModel();
        ViewBag.CompanyModel = new CompanySignupViewModel();
        return View();
    }

    // ════════════════════════════════════════════════════════════════════════
    // POST /candidate-signup-submit
    // ════════════════════════════════════════════════════════════════════════
    [HttpPost("/candidate-signup-submit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CandidateSignup(CandidateSignupViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CandidateModel = model;
            ViewBag.CompanyModel = new CompanySignupViewModel();
            TempData["SignupTab"] = "candidate";
            return View("Signup");
        }

        var (success, message) = await _auth.CandidateRegisterAsync(model);
        if (!success)
        {
            TempData["Error"] = message;
            TempData["SignupTab"] = "candidate";
            ViewBag.CandidateModel = model;
            ViewBag.CompanyModel = new CompanySignupViewModel();
            return View("Signup");
        }

        TempData["Success"] = message;
        return RedirectToAction("Login");
    }

    // ════════════════════════════════════════════════════════════════════════
    // POST /company-signup-submit
    // ════════════════════════════════════════════════════════════════════════
    [HttpPost("/company-signup-submit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CompanySignup(CompanySignupViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CandidateModel = new CandidateSignupViewModel();
            ViewBag.CompanyModel = model;
            TempData["SignupTab"] = "company";
            return View("Signup");
        }

        var (success, message) = await _auth.CompanyRegisterAsync(model);
        if (!success)
        {
            TempData["Error"] = message;
            TempData["SignupTab"] = "company";
            ViewBag.CandidateModel = new CandidateSignupViewModel();
            ViewBag.CompanyModel = model;
            return View("Signup");
        }

        TempData["Success"] = message;
        return RedirectToAction("Login");
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /{type}-signup-verify/{token}/{email}
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/{type}-signup-verify/{token}/{email}")]
    public async Task<IActionResult> VerifyEmail(string type, string token, string email)
    {
        (bool success, string message) = type.ToLower() switch
        {
            "candidate" => await _auth.VerifyCandidateEmailAsync(email, token),
            "company"   => await _auth.VerifyCompanyEmailAsync(email, token),
            _           => (false, "Loại người dùng không hợp lệ.")
        };

        TempData[success ? "Success" : "Error"] = message;
        return RedirectToAction("Login");
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /forget-password/{type}
    // POST /forget-password/{type}
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/forget-password/{type}")]
    public IActionResult ForgotPassword(string type)
    {
        ViewBag.UserType = type;
        return View(new ForgotPasswordViewModel());
    }

    [HttpPost("/forget-password/{type}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(string type, ForgotPasswordViewModel model)
    {
        ViewBag.UserType = type;
        if (!ModelState.IsValid)
            return View(model);

        var (success, message) = await _auth.SendForgotPasswordEmailAsync(model.Email, type);
        TempData[success ? "Success" : "Error"] = message;
        return View(model);
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /reset-password/{type}/{token}/{email}
    // POST /reset-password/{type}/{token}/{email}
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/reset-password/{type}/{token}/{email}")]
    public IActionResult ResetPassword(string type, string token, string email)
    {
        return View(new ResetPasswordViewModel { UserType = type, Token = token, Email = email });
    }

    [HttpPost("/reset-password/{type}/{token}/{email}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(string type, string token, string email, ResetPasswordViewModel model)
    {
        model.UserType = type;
        model.Token = token;
        model.Email = email;

        if (!ModelState.IsValid)
            return View(model);

        var (success, message) = await _auth.ResetPasswordAsync(model);
        if (!success)
        {
            TempData["Error"] = message;
            return View(model);
        }

        TempData["Success"] = message;
        return RedirectToAction("Login");
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /lecture-login — Trang đăng nhập giảng viên
    // POST /lecture-login-submit
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/lecture-login")]
    public IActionResult LectureLogin()
    {
        return View(new LectureLoginViewModel());
    }

    [HttpPost("/lecture-login-submit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LectureLoginSubmit(LectureLoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View("LectureLogin", model);

        var lecture = await _db.Lectures
            .Include(l => l.Role)
            .FirstOrDefaultAsync(l => l.LectureCode == model.LectureCode);

        if (lecture is null || string.IsNullOrEmpty(lecture.Password) || !BCrypt.Net.BCrypt.Verify(model.Password, lecture.Password))
        {
            TempData["Error"] = "Mã giảng viên hoặc mật khẩu không đúng.";
            return View("LectureLogin", model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, lecture.Id.ToString()),
            new(ClaimTypes.Name, lecture.Name),
            new(ClaimTypes.Email, lecture.Email),
            new(ClaimTypes.Role, "Lecture"),
            new("LectureRole", lecture.RoleId?.ToString() ?? "4"),
            new("LectureCode", lecture.LectureCode)
        };
        var identity = new ClaimsIdentity(claims, "LectureScheme");
        await HttpContext.SignInAsync("LectureScheme", new ClaimsPrincipal(identity));

        return RedirectToAction("Dashboard", "Lecture", new { area = "Lecture" });
    }

    // ════════════════════════════════════════════════════════════════════════
    // Google OAuth
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/login/google")]
    public IActionResult GoogleLogin(string returnUrl = "/")
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleCallback", new { returnUrl })
        };
        return Challenge(properties, "Google");
    }

    [HttpGet("/login/google/callback")]
    public async Task<IActionResult> GoogleCallback(string returnUrl = "/")
    {
        var result = await HttpContext.AuthenticateAsync("Google");
        if (!result.Succeeded)
        {
            TempData["Error"] = "Đăng nhập Google thất bại.";
            return RedirectToAction("Login");
        }

        var email = result.Principal.FindFirstValue(ClaimTypes.Email) ?? "";
        var name = result.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
        var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        if (string.IsNullOrEmpty(email))
        {
            TempData["Error"] = "Không lấy được email từ tài khoản Google.";
            return RedirectToAction("Login");
        }

        var candidate = await _auth.FindOrCreateCandidateByGoogleAsync(email, name, googleId);
        if (candidate is null)
        {
            TempData["Error"] = "Không thể tạo tài khoản từ Google.";
            return RedirectToAction("Login");
        }

        if (candidate.Status == 2)
        {
            TempData["Error"] = "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.";
            return RedirectToAction("Login");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, candidate.Id.ToString()),
            new(ClaimTypes.Name, candidate.Name),
            new(ClaimTypes.Email, candidate.Email),
            new(ClaimTypes.Role, "Candidate"),
            new("Photo", candidate.Photo ?? "default.png")
        };
        var identity = new ClaimsIdentity(claims, "CandidateScheme");
        await HttpContext.SignInAsync("CandidateScheme", new ClaimsPrincipal(identity));

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        return RedirectToAction("Index", "Dashboard", new { area = "Candidate" });
    }

    // ════════════════════════════════════════════════════════════════════════
    // Logout
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet("/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CandidateScheme");
        await HttpContext.SignOutAsync("CompanyScheme");
        return RedirectToAction("Login");
    }

    [HttpGet("/Auth/AccessDenied")]
    public IActionResult AccessDenied() => View();
}
