using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartCV.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminOnly")]
public abstract class AdminBaseController : Controller
{
    protected long GetAdminId()
        => long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    protected string GetAdminName()
        => User.FindFirstValue(ClaimTypes.Name) ?? "Admin";

    protected string GetAdminPhoto()
        => User.FindFirstValue("Photo") ?? "default.png";
}
