namespace HouseRentingSystem.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : AdminBaseController
{
    [HttpGet]
    public IActionResult Index() => View();
}