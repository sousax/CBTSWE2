using System.Diagnostics;
using CBTSWE2_TP02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CBTSWE2_TP02.Controllers
{
    //Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179
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
