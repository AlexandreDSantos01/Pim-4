using System.Collections.Generic; // Para manipular listas genéricas
using System.Linq; // Para consultas LINQ
using System.Threading.Tasks; // Para trabalhar com operações assíncronas
using Microsoft.AspNetCore.Mvc; // Para construir controladores e ações
using Microsoft.AspNetCore.Authorization; // Necessário para aplicar autorizações com [Authorize]
using Microsoft.EntityFrameworkCore; // Para interagir com o Entity Framework Core
using Web.Models; // Namespace que contém os modelos de dados

namespace Web.Controllers
{
    [Authorize] // Exige autenticação para acessar qualquer ação neste controlador
    [Route("api/[controller]")] // Define a rota base como "api/Clientes"
    [ApiController] // Indica que o controlador será usado para uma API
    public class ClientesController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        public ClientesController(MeuDbContext context)
        {
            _context = context; // Injeta o contexto do banco no construtor
        }

        // Retorna uma lista de todos os clientes em formato JSON
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.tb_Cliente.ToListAsync(); // Consulta todos os registros da tabela
        }

        // Retorna um cliente específico com base no ID
        [HttpGet("{id}")] // Rota: api/Clientes/{id}
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.tb_Cliente.FindAsync(id); // Busca o cliente pelo ID

            if (cliente == null) // Retorna 404 se o cliente não for encontrado
            {
                return NotFound();
            }

            return cliente; // Retorna o cliente encontrado
        }

        // Renderiza a View com a lista de clientes (HTML)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.tb_Cliente.ToListAsync();
            return View(clientes); // Passa os clientes para a View
        }

        // Renderiza a View com os detalhes de um cliente específico
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // Verifica se o ID foi informado
            {
                return NotFound();
            }

            var cliente = await _context.tb_Cliente.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null) // Verifica se o cliente foi encontrado
            {
                return NotFound();
            }

            return View(cliente); // Retorna a View com os dados do cliente
        }

        // Renderiza a View para criação de um novo cliente
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View(); // Apenas exibe a tela de criação
        }

        // Adiciona um novo cliente via API
        [HttpPost]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> PostCliente([Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (ModelState.IsValid) // Verifica se o modelo é válido
            {
                _context.tb_Cliente.Add(cliente); // Adiciona o cliente ao contexto
                await _context.SaveChangesAsync(); // Salva as alterações no banco
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente); // Retorna 201 Created
            }
            return BadRequest(ModelState); // Retorna 400 se o modelo for inválido
        }

        // Cria um novo cliente e redireciona para a lista de clientes
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente); // Adiciona o cliente
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redireciona para a lista
            }
            return View(cliente); // Retorna à View com os erros de validação
        }

        // Atualiza os dados de um cliente específico via API
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (id != cliente.Id) // Verifica se o ID fornecido corresponde ao cliente
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified; // Marca o cliente como modificado

            try
            {
                await _context.SaveChangesAsync(); // Tenta salvar as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id)) // Verifica se o cliente ainda existe
                {
                    return NotFound();
                }
                else
                {
                    throw; // Lança a exceção se outro erro ocorrer
                }
            }

            return NoContent(); // Retorna 204 No Content
        }

        // Renderiza a View para edição de um cliente específico
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

        // Atualiza os dados de um cliente e redireciona para a lista
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,Situacao")] Cliente cliente)
        {
            if (id != cliente.Id) // Verifica se o ID fornecido corresponde ao cliente
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente); // Atualiza os dados do cliente
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id)) // Verifica se o cliente ainda existe
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redireciona para a lista
            }
            return View(cliente); // Retorna à View em caso de erro
        }

        // Renderiza a View de confirmação para deletar um cliente
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

            return View(cliente); // Exibe a View de confirmação
        }

        // Exclui um cliente específico e redireciona para a lista
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.tb_Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.tb_Cliente.Remove(cliente); // Remove o cliente
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index)); // Redireciona para a lista
        }

        // Verifica se um cliente com o ID fornecido existe
        private bool ClienteExists(int id)
        {
            return _context.tb_Cliente.Any(e => e.Id == id); // Retorna true se o cliente existir
        }
    }
}
