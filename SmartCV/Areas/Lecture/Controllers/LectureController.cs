using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    [Authorize(Policy = "DeanOnly")]
    public async Task<IActionResult> LectureListing()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("LectureScheme");
        return RedirectToAction("LectureLogin", "Auth", new { area = "" });
    }
}
