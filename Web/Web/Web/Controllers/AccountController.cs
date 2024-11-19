using Microsoft.AspNetCore.Mvc; // Biblioteca para trabalhar com controladores e rotas no ASP.NET
using Web.Models; // Namespace do modelo de dados
using System.Linq; // Biblioteca para manipulação de coleções
using System.Threading.Tasks; // Biblioteca para tarefas assíncronas
using Microsoft.AspNetCore.Authentication; // Biblioteca para autenticação
using Microsoft.AspNetCore.Authentication.Cookies; // Biblioteca para autenticação baseada em cookies
using System.Security.Claims; // Biblioteca para manipular identidades e permissões
using System.Collections.Generic; // Biblioteca para trabalhar com listas e coleções genéricas
using BCrypt.Net; // Biblioteca para criptografia de senhas
using Microsoft.EntityFrameworkCore; // Biblioteca para trabalhar com Entity Framework Core

namespace Web.Controllers
{
    [Route("Account")] // Define a rota base para este controlador
    public class AccountController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados usado para acessar as tabelas

        public AccountController(MeuDbContext context)
        {
            _context = context; // Injeta o contexto do banco no construtor
        }

        // Exibe a tela de login
        [HttpGet("Login")] // Define a rota para a página de login usando o método GET
        public IActionResult Login()
        {
            return View(); // Retorna a View correspondente (provavelmente "Login.cshtml")
        }

        // Realiza o login
        [HttpPost("Login")] // Define a rota para o login usando o método POST
        [ValidateAntiForgeryToken] // Protege contra ataques de CSRF
        public async Task<IActionResult> Login(UserLogin model, string returnUrl = null)
        {
            if (ModelState.IsValid) // Verifica se os dados enviados no modelo são válidos
            {
                // Busca o usuário no banco de dados pelo nome de login
                var user = await _context.tb_Usuario
                    .FirstOrDefaultAsync(u => u.ulogar == model.ulogar);

                if (user != null) // Verifica se o usuário foi encontrado
                {
                    // Compara a senha fornecida com a armazenada no banco usando BCrypt
                    bool isPasswordValid = BCrypt.Net.BCrypt.EnhancedVerify(model.senha, user.senha);

                    if (isPasswordValid) // Se a senha for válida, realiza o login
                    {
                        // Cria as claims (informações de identidade do usuário)
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.ulogar), // Nome do usuário
                            // Aqui você pode adicionar mais claims, como permissões ou funções
                        };

                        // Configura a identidade e o esquema de autenticação por cookies
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        // Realiza o login do usuário com base na identidade configurada
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        // Redireciona para a página inicial (ou outra página definida no projeto)
                        return RedirectToAction("Index", "Home");
                    }
                }

                // Adiciona um erro ao modelo se o login falhar
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            }

            // Retorna a tela de login com os erros, se houver
            return View(model);
        }

        // Realiza o logout
        [HttpPost("Logout")] // Define a rota para logout usando o método POST
        [ValidateAntiForgeryToken] // Protege contra ataques de CSRF
        public async Task<IActionResult> Logout()
        {
            // Remove a autenticação do usuário
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redireciona para a tela de login após o logout
            return RedirectToAction("Login", "Account");
        }
    }
}
