using Microsoft.AspNetCore.Mvc;
using SmartCV.Data;

namespace SmartCV.Areas.Candidate.Controllers;

public class DashboardController : CandidateBaseController
{
    private readonly AppDbContext _db;

    public DashboardController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
