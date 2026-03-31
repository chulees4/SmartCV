using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCV.Data;

namespace SmartCV.Areas.Lecture.Controllers;

public class LectureController : LectureBaseController
{
    private readonly AppDbContext _db;

    public LectureController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Dashboard()
    {
        return View();
    }

    [Authorize(Policy = "DeanCommittee")]
    public async Task<IActionResult> Faculty()
    {
        return View();
    }

    [Authorize(Policy = "LeaderUp")]
    public async Task<IActionResult> JobListing(long? id = null)
    {
        return View();
    }

    public async Task<IActionResult> CandidateListing()
    {
        return View();
    }

    // Chi tiết ứng viên
    public async Task<IActionResult> CandidateDetail(long id)
    {
        var candidate = await _db.Candidates
            .Include(c => c.JobCategory)
            .Include(c => c.DesiredLocation)
            .Include(c => c.Educations)
            .Include(c => c.Skills)
            .Include(c => c.Experiences)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (candidate is null) return NotFound();
        return View(candidate);
    }

    [Authorize(Policy = "DeanOnly")]
    public async Task<IActionResult> LectureListing()
    {
        return View();
    }

    // Chi tiết giảng viên (chỉ Trưởng khoa)
    [Authorize(Policy = "DeanOnly")]
    public async Task<IActionResult> LectureDetail(long id)
    {
        var lecture = await _db.Lectures
            .Include(l => l.Faculty)
            .Include(l => l.Role)
            .Include(l => l.JobCategory)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (lecture is null) return NotFound();
        return View(lecture);
    }

    // Đổi mật khẩu
    [HttpGet]
    public IActionResult EditPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPassword(string currentPassword, string newPassword, string confirmPassword)
    {
        if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6)
        {
            TempData["Error"] = "Mật khẩu mới tối thiểu 6 ký tự.";
            return View();
        }

        if (newPassword != confirmPassword)
        {
            TempData["Error"] = "Mật khẩu xác nhận không khớp.";
            return View();
        }

        var lectureId = GetLectureId();
        var lecture = await _db.Lectures.FindAsync(lectureId);
        if (lecture is null) return NotFound();

        if (string.IsNullOrEmpty(lecture.Password) || !BCrypt.Net.BCrypt.Verify(currentPassword, lecture.Password))
        {
            TempData["Error"] = "Mật khẩu hiện tại không đúng.";
            return View();
        }

        lecture.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        lecture.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        TempData["Success"] = "Đổi mật khẩu thành công.";
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("LectureScheme");
        return RedirectToAction("LectureLogin", "Auth", new { area = "" });
    }
}
