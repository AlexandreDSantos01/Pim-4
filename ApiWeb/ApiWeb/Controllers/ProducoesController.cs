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
    public class ProducoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProducoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Producaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producao>>> GetProducoes()
        {
            return await _context.tb_Producao.ToListAsync();
        }

        // GET: api/Producaos/5
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

        // PUT: api/Producaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducao(int id, Producao producao)
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

        // POST: api/Producaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producao>> PostProducao(Producao producao)
        {
            _context.tb_Producao.Add(producao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducao", new { id = producao.Id }, producao);
        }

        // DELETE: api/Producaos/5
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

        private bool ProducaoExists(int id)
        {
            return _context.tb_Producao.Any(e => e.Id == id);
        }
    }
}
