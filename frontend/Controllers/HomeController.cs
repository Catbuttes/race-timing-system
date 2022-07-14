using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using frontend.Models;

namespace frontend.Controllers;

[Authorize]
[AuthorizeForScopes(Scopes = new string[] { "https://rtsusers.onmicrosoft.com/api/Api.Access" })]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Services.BackendService _downstream;

    public HomeController(ILogger<HomeController> logger, Services.BackendService downstream)
    {
        _logger = logger;
        _downstream = downstream;
    }

    public async Task<IActionResult> Index()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            ViewData["drivers"] = await _downstream.GetDrivers(User);
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
