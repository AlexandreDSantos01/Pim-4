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
    public class ProducoesController : Controller
    {
        private readonly MeuDbContext _context;

        public ProducoesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: api/Producoes (JSON API)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producao>>> GetProducoes()
        {
            return await _context.tb_Producao.ToListAsync();
        }

        // GET: api/Producoes/5 (JSON API)
        [HttpGet("{id}")]
        public async Task<ActionResult<Producao>> GetProducao(int id)
        {
            var producao = await _context.tb_Producao.FindAsync(id);

            if (producao == null)
            {
                return NotFound();
            }

            return producao;
        }

        // GET: Producoes (HTML View)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            var producoes = await _context.tb_Producao.ToListAsync();
            return View(producoes);
        }

        // GET: Producoes/Details/5 (HTML View)
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producao = await _context.tb_Producao.FirstOrDefaultAsync(m => m.Id == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // GET: Producoes/Create (HTML View)
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producoes/Create (HTML View)
        [HttpPost("create")]
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
        [HttpPost]
        public async Task<IActionResult> PostProducao([FromBody] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Producao.Add(producao);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProducao), new { id = producao.Id }, producao);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Producoes/5 (JSON API)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducao(int id, [FromBody] Producao producao)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducao(int id)
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
