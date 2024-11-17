using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; // Importar para usar o [Authorize]
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    [Authorize] // Protege todo o controlador
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly MeuDbContext _context;

        public ClientesController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.tb_Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.tb_Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: Clientes - Renderiza a View com a lista de clientes em HTML
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.tb_Cliente.ToListAsync();
            return View(clientes);
        }

        // GET: Clientes/Details/5 - Renderiza a View de detalhes do cliente em HTML
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.tb_Cliente.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create - Renderiza a View de criação do cliente em HTML
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: api/Clientes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCliente([Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Cliente.Add(cliente);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
            }
            return BadRequest(ModelState);
        }

        // POST: Clientes/Create - Cria o cliente e redireciona para a lista
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // GET: Clientes/Edit/5 - Renderiza a View de edição do cliente em HTML
        [HttpGet("view/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.tb_Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5 - Atualiza o cliente e redireciona para a lista
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5 - Renderiza a View de confirmação para deletar cliente em HTML
        [HttpGet("view/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.tb_Cliente.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: api/Clientes/Delete/5 - Confirma a exclusão e redireciona para a lista
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.tb_Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.tb_Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.tb_Cliente.Any(e => e.Id == id);
        }
    }
}
