using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class EstoquesController : Controller
    {
        private readonly MeuDbContext _context;

        public EstoquesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Estoques (HTML View)
        public async Task<IActionResult> Index()
        {
            return View(await _context.tb_Estoque.ToListAsync());
        }

        // GET: api/Estoques (JSON API)
        [HttpGet("api/Estoques")]
        public async Task<IActionResult> GetEstoquesJson()
        {
            var estoques = await _context.tb_Estoque.ToListAsync();
            return Json(estoques);
        }

        // GET: Estoques/Details/5 (HTML View)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: api/Estoques/5 (JSON API)
        [HttpGet("api/Estoques/{id}")]
        public async Task<IActionResult> GetEstoqueJson(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }

            return Json(estoque);
        }

        // POST: Estoques/Create (HTML View)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,DColheita,DRegistroProducao,EstimativaProducao,Validade,ValorNutritivo,Preco,Situacao")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estoque);
        }

        // POST: api/Estoques (JSON API)
        [HttpPost("api/Estoques")]
        public async Task<IActionResult> PostEstoqueJson([FromBody] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Estoque.Add(estoque);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEstoqueJson), new { id = estoque.Id }, estoque);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Estoques/5 (JSON API)
        [HttpPut("api/Estoques/{id}")]
        public async Task<IActionResult> PutEstoqueJson(int id, [FromBody] Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return BadRequest();
            }

            _context.Entry(estoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Estoques/5 (JSON API)
        [HttpDelete("api/Estoques/{id}")]
        public async Task<IActionResult> DeleteEstoqueJson(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }

            _context.tb_Estoque.Remove(estoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstoqueExists(int id)
        {
            return _context.tb_Estoque.Any(e => e.Id == id);
        }
    }
}
