using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Adicione esta linha se ainda não estiver presente
using Web.Models;

[Authorize] // Apenas usuários autenticados podem acessar este controlador
public class PermissaoController : Controller
{
    private readonly ApplicationDbContext _context;

    public PermissaoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Ação para listar produtos (acesso para Admin e Viewer)
    [Authorize(Roles = "Admin,Viewer")]
    public IActionResult Index()
    {
        var produtos = _context.Produtos.ToList(); // Certifique-se de que Produtos seja um DbSet<Produto>
        return View(produtos);
    }

    // Ação para criar produtos (apenas para Admin)
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de produtos
        }
        return View(produto); // Retorna a mesma view com o produto não válido
    }

    // Ação para editar produtos (apenas para Admin)
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound(); // Retorna 404 se o produto não for encontrado
        }
        return View(produto);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de produtos
        }
        return View(produto); // Retorna a mesma view com o produto não válido
    }

    // Ação para deletar produtos (apenas para Admin)
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound(); // Retorna 404 se o produto não for encontrado
        }
        return View(produto);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteConfirmed(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto != null) // Verifica se o produto existe
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index)); // Redireciona para a lista de produtos
    }
}
