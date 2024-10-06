using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ProjetoWeb.Models; // Adicione o namespace do RegisterViewModel aqui

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager; // Adicionando o UserManager

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager; // Inicializando o UserManager
    }

    // Método GET para exibir a tela de login
    [HttpGet]
    public IActionResult Login()
    {
        return View(); // Retorna a view de login
    }

    // Método POST para processar o login
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home"); // Redireciona para a Home após login
        }

        ModelState.AddModelError("", "Login inválido");
        return View(); // Retorna a view de login em caso de falha
    }

    // Método para realizar o logout
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account"); // Redireciona para a página de login após logout
    }

    // Adicionando o método GET para exibir o formulário de registro
    [HttpGet]
    public IActionResult Register()
    {
        return View(); // Retorna a view de registro
    }

    // Método POST para registrar um novo usuário
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Usuário registrado com sucesso
                return RedirectToAction("Index", "Home"); // Redireciona para a Home
            }

            // Exibe os erros de criação de usuário
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View(model); // Retorna a view de registro em caso de falha
    }
}
