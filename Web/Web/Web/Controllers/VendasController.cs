using System; // Namespace básico do .NET
using System.Collections.Generic; // Necessário para trabalhar com coleções genéricas
using System.Linq; // Usado para consultas LINQ
using System.Threading.Tasks; // Permite uso de métodos assíncronos
using Microsoft.AspNetCore.Authorization; // Usado para aplicar políticas de autenticação
using Microsoft.AspNetCore.Mvc; // Fornece funcionalidades para controladores e ações
using Microsoft.EntityFrameworkCore; // Necessário para interagir com o banco de dados
using Web.Models; // Contém os modelos usados na aplicação

namespace Web.Controllers
{
    // O controlador está protegido, todas as ações exigem autenticação para serem acessadas
    [Authorize]
    [Route("api/[controller]")] // Define a rota base como "api/Vendas"
    [ApiController] // Identifica que este é um controlador de API
    public class VendasController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        // Construtor que injeta o contexto do banco de dados
        public VendasController(MeuDbContext context)
        {
            _context = context;
        }

        // Retorna todas as vendas em formato JSON, incluindo dados relacionados (Cliente e Estoque)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendas()
        {
            return await _context.tb_Venda
                .Include(v => v.Cliente) // Inclui os dados do cliente relacionados
                .Include(v => v.Estoque) // Inclui os dados do estoque relacionados
                .ToListAsync(); // Converte para uma lista assíncronamente
        }

        // Retorna uma venda específica em formato JSON, incluindo Cliente e Estoque
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.tb_Venda
                .Include(v => v.Cliente) // Inclui os dados do cliente relacionados
                .Include(v => v.Estoque) // Inclui os dados do estoque relacionados
                .FirstOrDefaultAsync(v => v.Id == id); // Busca a venda pelo ID

            if (venda == null)
            {
                return NotFound(); // Retorna 404 caso a venda não seja encontrada
            }

            return venda; // Retorna a venda encontrada
        }

        // Exibe a lista de vendas em uma view (HTML)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            var vendas = await _context.tb_Venda
                .Include(v => v.Cliente) // Inclui os dados do cliente
                .Include(v => v.Estoque) // Inclui os dados do estoque
                .ToListAsync();
            return View(vendas); // Passa a lista para a view
        }

        // Exibe os detalhes de uma venda específica em uma view (HTML)
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 caso o ID não seja fornecido
            }

            var venda = await _context.tb_Venda
                .Include(v => v.Cliente) // Inclui os dados do cliente
                .Include(v => v.Estoque) // Inclui os dados do estoque
                .FirstOrDefaultAsync(m => m.Id == id);

            if (venda == null)
            {
                return NotFound(); // Retorna 404 caso a venda não seja encontrada
            }

            return View(venda); // Retorna a view com os detalhes da venda
        }

        // Exibe o formulário para criar uma nova venda
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View(); // Retorna a view de criação
        }

        // Processa a criação de uma nova venda
        [HttpPost("create")]
        [ValidateAntiForgeryToken] // Proteção contra CSRF
        public async Task<IActionResult> Create([Bind("Id,ClienteId,EstoqueId,Nome,Quantidade,DRegistro,Valor")] Venda venda)
        {
            if (ModelState.IsValid) // Verifica se os dados fornecidos são válidos
            {
                _context.Add(venda); // Adiciona a nova venda ao banco
                await _context.SaveChangesAsync(); // Salva as alterações no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de vendas
            }
            return View(venda); // Retorna à view caso os dados sejam inválidos
        }

        // Exibe o formulário de edição para uma venda específica
        [HttpGet("view/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 caso o ID não seja fornecido
            }

            var venda = await _context.tb_Venda.FindAsync(id); // Busca a venda pelo ID
            if (venda == null)
            {
                return NotFound(); // Retorna 404 caso a venda não seja encontrada
            }
            return View(venda); // Retorna a view de edição
        }

        // Processa a edição de uma venda
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,EstoqueId,Nome,Quantidade,DRegistro,Valor")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound(); // Retorna 404 caso os IDs não coincidam
            }

            if (ModelState.IsValid) // Verifica se os dados fornecidos são válidos
            {
                try
                {
                    _context.Update(venda); // Atualiza a venda no banco de dados
                    await _context.SaveChangesAsync(); // Salva as alterações
                }
                catch (DbUpdateConcurrencyException) // Trata erros de concorrência
                {
                    if (!VendaExists(venda.Id)) // Verifica se a venda existe
                    {
                        return NotFound(); // Retorna 404 caso não exista
                    }
                    else
                    {
                        throw; // Relança a exceção
                    }
                }
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de vendas
            }
            return View(venda); // Retorna à view caso os dados sejam inválidos
        }

        // Exibe o formulário de confirmação para exclusão de uma venda
        [HttpGet("view/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 caso o ID não seja fornecido
            }

            var venda = await _context.tb_Venda
                .Include(v => v.Cliente) // Inclui os dados do cliente
                .Include(v => v.Estoque) // Inclui os dados do estoque
                .FirstOrDefaultAsync(m => m.Id == id);

            if (venda == null)
            {
                return NotFound(); // Retorna 404 caso a venda não seja encontrada
            }

            return View(venda); // Retorna a view de exclusão
        }

        // Processa a exclusão de uma venda
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.tb_Venda.FindAsync(id); // Busca a venda pelo ID
            if (venda != null)
            {
                _context.tb_Venda.Remove(venda); // Remove a venda do banco de dados
                await _context.SaveChangesAsync(); // Salva as alterações
            }

            return RedirectToAction(nameof(Index)); // Redireciona para a lista de vendas
        }

        // Método auxiliar para verificar se uma venda existe no banco
        private bool VendaExists(int id)
        {
            return _context.tb_Venda.Any(e => e.Id == id); // Retorna true se a venda existir
        }
    }
}
