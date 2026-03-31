using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartCV.Areas.Candidate.Controllers;

[Area("Candidate")]
[Authorize(Policy = "CandidateOnly")]
public abstract class CandidateBaseController : Controller
{
    protected long GetCandidateId()
        => long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    protected string GetCandidateName()
        => User.FindFirstValue(ClaimTypes.Name) ?? "";

    protected string GetCandidatePhoto()
        => User.FindFirstValue("Photo") ?? "default.png";
}
