﻿namespace Homies.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction(nameof(EventController.All), "Event");
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}