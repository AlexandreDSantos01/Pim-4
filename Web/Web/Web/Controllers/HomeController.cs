using Microsoft.AspNetCore.Authorization; // Necess�rio para usar o atributo [Authorize]
using Microsoft.AspNetCore.Mvc; // Fornece suporte para criar controladores e a��es
using System.Diagnostics; // Usado para acessar informa��es sobre a atividade atual, como ID de solicita��o
using Web.Models; // Namespace contendo os modelos da aplica��o

namespace Web.Controllers
{
    [Authorize] // Garante que todas as a��es neste controlador s� podem ser acessadas por usu�rios autenticados
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Servi�o de logging para registrar informa��es e diagn�sticos

        // Construtor que injeta o servi�o de logging no controlador
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // A��o principal que retorna a view da p�gina inicial
        // Esta a��o est� protegida pelo atributo [Authorize]
        public IActionResult Index()
        {
            return View(); // Retorna a view padr�o associada � a��o "Index"
        }

        // A��o que retorna a view da p�gina de privacidade
        // Tamb�m est� protegida pelo atributo [Authorize]
        public IActionResult Privacy()
        {
            return View(); // Retorna a view padr�o associada � a��o "Privacy"
        }

        // A��o usada para lidar com erros e exibir uma p�gina de erro
        // [ResponseCache]: Configura o cache para evitar armazenar a resposta no cliente ou no servidor
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Cria um modelo de erro que inclui o ID da solicita��o atual para ajudar no diagn�stico
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel); // Retorna a view de erro com o modelo preenchido
        }
    }
}
