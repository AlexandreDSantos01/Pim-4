using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWeb.Data;
using ApiWeb.Models;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinanceirosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Financeiroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financeiro>>> GetFinanceiros()
        {
            return await _context.tb_Financeiro.ToListAsync();
        }

        // GET: api/Financeiroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financeiro>> GetFinanceiro(int id)
        {
            var financeiro = await _context.tb_Financeiro.FindAsync(id);

            if (financeiro == null)
            {
                return NotFound();
            }

            return financeiro;
        }

        // PUT: api/Financeiroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceiro(int id, Financeiro financeiro)
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

        // POST: api/Financeiroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Financeiro>> PostFinanceiro(Financeiro financeiro)
        {
            _context.tb_Financeiro.Add(financeiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinanceiro", new { id = financeiro.Id }, financeiro);
        }

        // DELETE: api/Financeiroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceiro(int id)
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
