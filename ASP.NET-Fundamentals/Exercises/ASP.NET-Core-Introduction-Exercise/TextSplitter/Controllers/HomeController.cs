using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitter.Models;

namespace TextSplitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel model) => View(model);

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            model.SplitText = model.Text.Replace(" ", Environment.NewLine);
            return RedirectToAction(nameof(Index), model);
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
}
