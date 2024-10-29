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
    public class DespesasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DespesasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Despesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesas()
        {
            return await _context.tb_Despesa.ToListAsync();
        }

        // GET: api/Despesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            var despesa = await _context.tb_Despesa.FindAsync(id);

            if (despesa == null)
            {
                return NotFound();
            }

            return despesa;
        }

        // PUT: api/Despesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesa(int id, Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(despesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesaExists(id))
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

        // POST: api/Despesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Despesa>> PostDespesa(Despesa despesa)
        {
            _context.tb_Despesa.Add(despesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDespesa", new { id = despesa.Id }, despesa);
        }

        // DELETE: api/Despesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _context.tb_Despesa.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }

            _context.tb_Despesa.Remove(despesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DespesaExists(int id)
        {
            return _context.tb_Despesa.Any(e => e.Id == id);
        }
    }
}
