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
    public class FinanceirosController : Controller
    {
        private readonly MeuDbContext _context;

        public FinanceirosController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Financeiros (HTML View)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.tb_Financeiro.ToListAsync());
        }

        // GET: api/Financeiros (JSON API)
        [HttpGet]
        public async Task<IActionResult> GetFinanceirosJson()
        {
            var financeiros = await _context.tb_Financeiro.ToListAsync();
            return Json(financeiros);
        }

        // GET: Financeiros/Details/5 (HTML View)
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.tb_Financeiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // GET: api/Financeiros/5 (JSON API)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinanceiroJson(int id)
        {
            var financeiro = await _context.tb_Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return Json(financeiro);
        }

        // POST: Financeiros/Create (HTML View)
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DRegistro,DiaInicio,DiaFim,ValorVenda,ValorDespesa,ValorLucro")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financeiro);
        }

        // POST: api/Financeiros (JSON API)
        [HttpPost]
        public async Task<IActionResult> PostFinanceiroJson([FromBody] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Financeiro.Add(financeiro);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFinanceiroJson), new { id = financeiro.Id }, financeiro);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Financeiros/5 (JSON API)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceiroJson(int id, [FromBody] Financeiro financeiro)
        {
            if (id != financeiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(financeiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceiroExists(id))
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

        // DELETE: api/Financeiros/5 (JSON API)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceiroJson(int id)
        {
            var financeiro = await _context.tb_Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }

            _context.tb_Financeiro.Remove(financeiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanceiroExists(int id)
        {
            return _context.tb_Financeiro.Any(e => e.Id == id);
        }
    }
}
