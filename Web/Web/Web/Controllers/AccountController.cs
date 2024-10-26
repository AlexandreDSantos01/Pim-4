using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Web.Models;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly MeuDbContext _context;

        public AccountController(MeuDbContext context)
        {
            _context = context;
        }

        // Método para exibir a página de login (HTML)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Método para login via API que retorna HTML
        [HttpPost]
        [Route("api/account/login")]
        public async Task<IActionResult> LoginApi(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o usuário existe no banco de dados
                var user = _context.tb_Usuario.FirstOrDefault(u => u.Ulogar == model.Ulogar);

                // Verifica se o usuário foi encontrado e se a senha está correta
                if (user != null && user.Senha == model.Senha) // Certifique-se de adaptar a lógica de senha conforme necessário
                {
                    // Configura as claims para autenticação
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Ulogar)
                    };

                    // Cria a identidade do usuário
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Configura o cookie de autenticação
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Retorna a página inicial após login bem-sucedido
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Nome de usuário ou senha inválidos.");
            }

            // Se a validação falhar, retorna a mesma view com o modelo
            return View("Login", model);
        }

        // Método para logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
