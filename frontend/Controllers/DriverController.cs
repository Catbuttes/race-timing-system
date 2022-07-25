using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using frontend.Models;

namespace frontend.Controllers;

[Authorize]
[AuthorizeForScopes(Scopes = new string[] { "https://rtsusers.onmicrosoft.com/rtsapi/Api.Access" })]
public class DriverController : Controller
{
    private readonly ILogger<DriverController> _logger;
    private Services.BackendService _downstream;

    public DriverController(ILogger<DriverController> logger, Services.BackendService downstream)
    {
        _logger = logger;
        _downstream = downstream;
    }

    public async Task<IActionResult> Index()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            ViewData["drivers"] = await _downstream.GetAllDrivers(User);
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
