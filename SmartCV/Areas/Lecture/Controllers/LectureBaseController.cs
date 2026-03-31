using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartCV.Areas.Lecture.Controllers;

[Area("Lecture")]
[Authorize(Policy = "LectureOnly")]
public abstract class LectureBaseController : Controller
{
    protected long GetLectureId()
        => long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    protected string GetLectureName()
        => User.FindFirstValue(ClaimTypes.Name) ?? "";

    protected string GetLectureCode()
        => User.FindFirstValue("LectureCode") ?? "";

    protected int GetLectureRoleId()
        => int.TryParse(User.FindFirstValue("LectureRole"), out var r) ? r : 4;
}
