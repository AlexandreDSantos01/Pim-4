using Microsoft.AspNetCore.Mvc;
using Web.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly MeuDbContext _context;

        public AccountController(MeuDbContext context)
        {
            _context = context;
        }

        // Exibe a tela de login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        // Realiza o login
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.tb_Usuario
                    .FirstOrDefaultAsync(u => u.ulogar == model.ulogar); // Usando model.ulogar

                if (user != null)
                {
                    bool isPasswordValid = BCrypt.Net.BCrypt.EnhancedVerify(model.senha, user.senha);

                    if (isPasswordValid)
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.ulogar),
                    // Use o campo correto de role se tiver
                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            }

            return View(model);
        }

        // Logout
        [HttpPost("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
