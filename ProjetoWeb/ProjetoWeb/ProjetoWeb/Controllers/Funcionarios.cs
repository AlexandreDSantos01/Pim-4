using Microsoft.AspNetCore.Mvc;

namespace ProjetoWeb.Controllers
{
    public class Funcionarios : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
