namespace HouseRentingSystem.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Home;

public class HomeController : Controller
{
    public IActionResult Index() => View(new IndexViewModel());

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}