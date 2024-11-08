using lr11.Filters;
using Microsoft.AspNetCore.Mvc;
using lr11.Models;
using System.Diagnostics;

namespace lr11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // ќтримуЇмо к≥льк≥сть ун≥кальних користувач≥в
            var uniqueUserCount = UnFilter.GetUniqueUserCount();
            ViewData["UniqueUserCount"] = uniqueUserCount;
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
}
