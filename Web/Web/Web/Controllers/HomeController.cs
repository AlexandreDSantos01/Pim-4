using Microsoft.AspNetCore.Authorization; // Necessário para usar [Authorize]
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    [Authorize] // Protege todas as ações do controlador
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Esta ação requer autenticação devido ao [Authorize] aplicado no controlador
        public IActionResult Index()
        {
            return View();
        }

        // Esta ação também está protegida
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
