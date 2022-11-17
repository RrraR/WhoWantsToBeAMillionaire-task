﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhoWantsToBeAMillionaire_task.Models;
using WhoWantsToBeAMillionaire_task.Service;
using WWTBAM.Data;
using WWTBAM.Data.Repository;

namespace WhoWantsToBeAMillionaire_task.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Result(WWTBAMGameViewModel model)
    {
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}