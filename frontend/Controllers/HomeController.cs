﻿using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using frontend.Models;

namespace frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Services.BackendService _downstream;
    private string backend;

    public HomeController(ILogger<HomeController> logger, Services.BackendService downstream, IConfiguration _config)
    {
        _logger = logger;
        _downstream = downstream;
        backend = _config.GetValue<string>("BackendConfig:BaseUrl");
    }

    public async Task<IActionResult> Index()
    {

        ViewData["backend"] = backend;
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
