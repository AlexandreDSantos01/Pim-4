using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly MeuDbContext _context;

        public FornecedoresController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: Fornecedores (HTML View)
        public async Task<IActionResult> Index()
        {
            return View(await _context.tb_Fornecedor.ToListAsync());
        }

        // GET: api/Fornecedores (JSON API)
        [HttpGet("api/Fornecedores")]
        public async Task<IActionResult> GetFornecedoresJson()
        {
            var fornecedores = await _context.tb_Fornecedor.ToListAsync();
            return Json(fornecedores);
        }

        // GET: Fornecedores/Details/5 (HTML View)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.tb_Fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: api/Fornecedores/5 (JSON API)
        [HttpGet("api/Fornecedores/{id}")]
        public async Task<IActionResult> GetFornecedorJson(int id)
        {
            var fornecedor = await _context.tb_Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return Json(fornecedor);
        }

        // POST: Fornecedores/Create (HTML View)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cnpj,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Produtos,Situacao")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // POST: api/Fornecedores (JSON API)
        [HttpPost("api/Fornecedores")]
        public async Task<IActionResult> PostFornecedorJson([FromBody] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Fornecedor.Add(fornecedor);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFornecedorJson), new { id = fornecedor.Id }, fornecedor);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Fornecedores/5 (JSON API)
        [HttpPut("api/Fornecedores/{id}")]
        public async Task<IActionResult> PutFornecedorJson(int id, [FromBody] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
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

        // DELETE: api/Fornecedores/5 (JSON API)
        [HttpDelete("api/Fornecedores/{id}")]
        public async Task<IActionResult> DeleteFornecedorJson(int id)
        {
            var fornecedor = await _context.tb_Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.tb_Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.tb_Fornecedor.Any(e => e.Id == id);
        }
    }
}
