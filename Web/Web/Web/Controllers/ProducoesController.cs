using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class ProducoesController : Controller
    {
        private readonly MeuDbContext _context;

        public ProducoesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Producoes (HTML View)
        public async Task<IActionResult> Index()
        {
            var producoes = await _context.tb_Producao.ToListAsync();
            return View(producoes);
        }

        // GET: api/Producoes (JSON API)
        [HttpGet("api/Producoes")]
        public async Task<IActionResult> GetProducoesJson()
        {
            var producoes = await _context.tb_Producao.ToListAsync();
            return Json(producoes);
        }

        // GET: Producoes/Details/5 (HTML View)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producao = await _context.tb_Producao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // GET: api/Producoes/5 (JSON API)
        [HttpGet("api/Producoes/{id}")]
        public async Task<IActionResult> GetProducaoJson(int id)
        {
            var producao = await _context.tb_Producao.FindAsync(id);
            if (producao == null)
            {
                return NotFound();
            }

            return Json(producao);
        }

        // GET: Producoes/Create (HTML View)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producoes/Create (HTML View)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,DRegistro,Estimativa")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producao);
        }

        // POST: api/Producoes (JSON API)
        [HttpPost("api/Producoes")]
        public async Task<IActionResult> PostProducaoJson([FromBody] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Producao.Add(producao);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProducaoJson), new { id = producao.Id }, producao);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Producoes/5 (JSON API)
        [HttpPut("api/Producoes/{id}")]
        public async Task<IActionResult> PutProducaoJson(int id, [FromBody] Producao producao)
        {
            if (id != producao.Id)
            {
                return BadRequest();
            }

            _context.Entry(producao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducaoExists(id))
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

        // DELETE: api/Producoes/5 (JSON API)
        [HttpDelete("api/Producoes/{id}")]
        public async Task<IActionResult> DeleteProducaoJson(int id)
        {
            var producao = await _context.tb_Producao.FindAsync(id);
            if (producao == null)
            {
                return NotFound();
            }

            _context.tb_Producao.Remove(producao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if a production exists
        private bool ProducaoExists(int id)
        {
            return _context.tb_Producao.Any(e => e.Id == id);
        }
    }
}
