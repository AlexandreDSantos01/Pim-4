using Microsoft.AspNetCore.Authorization; // Necess�rio para usar [Authorize]
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    [Authorize] // Protege todas as a��es do controlador
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Esta a��o requer autentica��o devido ao [Authorize] aplicado no controlador
        public IActionResult Index()
        {
            return View();
        }

        // Esta a��o tamb�m est� protegida
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
