﻿using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View(DataAccess.Cars);
    }
}
