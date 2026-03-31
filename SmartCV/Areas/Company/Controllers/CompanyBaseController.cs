using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartCV.Areas.Company.Controllers;

[Area("Company")]
[Authorize(Policy = "CompanyOnly")]
public abstract class CompanyBaseController : Controller
{
    protected long GetCompanyId()
        => long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    protected string GetCompanyName()
        => User.FindFirstValue(ClaimTypes.Name) ?? "";

    protected string GetCompanyPhoto()
        => User.FindFirstValue("Photo") ?? "default.png";
}
