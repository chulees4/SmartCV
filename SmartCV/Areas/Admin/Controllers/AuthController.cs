using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCV.Data;
using SmartCV.Services.Interfaces;
using SmartCV.ViewModels.Auth;
using System.Security.Claims;

namespace SmartCV.Areas.Admin.Controllers;

[Area("Admin")]
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
    // GET /Admin/Auth/Login
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        return View(new LoginViewModel());
    }

    // ════════════════════════════════════════════════════════════════════════
    // POST /Admin/Auth/Login
    // ════════════════════════════════════════════════════════════════════════
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Email == model.Email);
        if (admin is null || !BCrypt.Net.BCrypt.Verify(model.Password, admin.Password))
        {
            TempData["Error"] = "Email hoặc mật khẩu không đúng.";
            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, admin.Id.ToString()),
            new(ClaimTypes.Name, admin.Name),
            new(ClaimTypes.Email, admin.Email),
            new(ClaimTypes.Role, "Admin"),
            new("Photo", admin.Photo)
        };
        var identity = new ClaimsIdentity(claims, "AdminScheme");
        var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
        await HttpContext.SignInAsync("AdminScheme", new ClaimsPrincipal(identity), props);

        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /Admin/Auth/ForgotPassword
    // POST /Admin/Auth/ForgotPassword
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet]
    public IActionResult ForgotPassword() => View(new ForgotPasswordViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var (success, message) = await _auth.SendForgotPasswordEmailAsync(model.Email, "admin");
        TempData[success ? "Success" : "Error"] = message;
        return View(model);
    }

    // ════════════════════════════════════════════════════════════════════════
    // GET /Admin/Auth/ResetPassword
    // POST /Admin/Auth/ResetPassword
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet]
    public IActionResult ResetPassword(string token, string email)
        => View(new ResetPasswordViewModel { UserType = "admin", Token = token, Email = email });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        model.UserType = "admin";
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
    // GET /Admin/Auth/Logout
    // ════════════════════════════════════════════════════════════════════════
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("AdminScheme");
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult AccessDenied() => View();
}
