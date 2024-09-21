using Microsoft.AspNetCore.Authorization; // Adicione esta linha no início
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    [Authorize] // Apenas usuários autenticados podem acessar este controlador
    public class PermissoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PermissoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Viewer")] // Ambos Admin e Viewer podem acessar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Permissao.ToListAsync());
        }

        [Authorize(Roles = "Admin")] // Apenas Admin pode acessar
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Apenas Admin pode acessar
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NivelAcesso")] Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permissao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permissao);
        }

        [Authorize(Roles = "Admin")] // Apenas Admin pode acessar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissao = await _context.Permissao.FindAsync(id);
            if (permissao == null)
            {
                return NotFound();
            }
            return View(permissao);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Apenas Admin pode acessar
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NivelAcesso")] Permissao permissao)
        {
            if (id != permissao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permissao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissaoExists(permissao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(permissao);
        }

        [Authorize(Roles = "Admin")] // Apenas Admin pode acessar
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissao = await _context.Permissao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permissao == null)
            {
                return NotFound();
            }

            return View(permissao);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")] // Apenas Admin pode acessar
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permissao = await _context.Permissao.FindAsync(id);
            if (permissao != null)
            {
                _context.Permissao.Remove(permissao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissaoExists(int id)
        {
            return _context.Permissao.Any(e => e.Id == id);
        }
    }
}
