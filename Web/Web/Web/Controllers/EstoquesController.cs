using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesController : Controller
    {
        private readonly MeuDbContext _context;

        public EstoquesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: api/Estoques (JSON API)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoques()
        {
            return await _context.tb_Estoque.ToListAsync();
        }

        // GET: api/Estoques/5 (JSON API)
        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetEstoque(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);

            if (estoque == null)
            {
                return NotFound();
            }

            return estoque;
        }

        // GET: Estoques (HTML View)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.tb_Estoque.ToListAsync());
        }

        // GET: Estoques/Details/5 (HTML View)
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque.FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create (HTML View)
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estoques/Create (HTML View)
        [HttpPost("create")]
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

        // GET: Estoques/Edit/5 (HTML View)
        [HttpGet("view/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Edit/5 (HTML View)
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,DColheita,DRegistroProducao,EstimativaProducao,Validade,ValorNutritivo,Preco,Situacao")] Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.Id))
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
            return View(estoque);
        }

        // GET: Estoques/Delete/5 (HTML View)
        [HttpGet("view/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque.FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5 (HTML View)
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque != null)
            {
                _context.tb_Estoque.Remove(estoque);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: api/Estoques (JSON API)
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostEstoque([FromBody] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Estoque.Add(estoque);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEstoque), new { id = estoque.Id }, estoque);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Estoques/5 (JSON API)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int id, [FromBody] Estoque estoque)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstoque(int id)
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
