using Microsoft.AspNetCore.Authorization; // Necessário para usar o atributo [Authorize]
using Microsoft.AspNetCore.Mvc; // Fornece suporte para criar controladores e ações
using System.Diagnostics; // Usado para acessar informações sobre a atividade atual, como ID de solicitação
using Web.Models; // Namespace contendo os modelos da aplicação

namespace Web.Controllers
{
    [Authorize] // Garante que todas as ações neste controlador só podem ser acessadas por usuários autenticados
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Serviço de logging para registrar informações e diagnósticos

        // Construtor que injeta o serviço de logging no controlador
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ação principal que retorna a view da página inicial
        // Esta ação está protegida pelo atributo [Authorize]
        public IActionResult Index()
        {
            return View(); // Retorna a view padrão associada à ação "Index"
        }

        // Ação que retorna a view da página de privacidade
        // Também está protegida pelo atributo [Authorize]
        public IActionResult Privacy()
        {
            return View(); // Retorna a view padrão associada à ação "Privacy"
        }

        // Ação usada para lidar com erros e exibir uma página de erro
        // [ResponseCache]: Configura o cache para evitar armazenar a resposta no cliente ou no servidor
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Cria um modelo de erro que inclui o ID da solicitação atual para ajudar no diagnóstico
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel); // Retorna a view de erro com o modelo preenchido
        }
    }
}
