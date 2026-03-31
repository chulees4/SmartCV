using Microsoft.AspNetCore.Mvc;
using SmartCV.Data;

namespace SmartCV.Areas.Company.Controllers;

public class DashboardController : CompanyBaseController
{
    private readonly AppDbContext _db;

    public DashboardController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
