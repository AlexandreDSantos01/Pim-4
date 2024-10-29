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
    public class EstoquesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstoquesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estoques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoques()
        {
            return await _context.tb_Estoque.ToListAsync();
        }

        // GET: api/Estoques/5
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

        // PUT: api/Estoques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int id, Estoque estoque)
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

        // POST: api/Estoques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostEstoque(Estoque estoque)
        {
            _context.tb_Estoque.Add(estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoque", new { id = estoque.Id }, estoque);
        }

        // DELETE: api/Estoques/5
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
