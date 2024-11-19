using System; // Necessário para tipos básicos
using System.Collections.Generic; // Para manipular listas genéricas
using System.Linq; // Para consultas LINQ
using System.Threading.Tasks; // Para operações assíncronas
using Microsoft.AspNetCore.Authorization; // Necessário para aplicar [Authorize]
using Microsoft.AspNetCore.Mvc; // Para construir controladores e ações
using Microsoft.EntityFrameworkCore; // Para interagir com o Entity Framework Core
using Web.Models; // Namespace que contém os modelos de dados

namespace Web.Controllers
{
    [Authorize] // Exige autenticação para acessar qualquer ação deste controlador
    [Route("api/[controller]")] // Define a rota base como "api/Despesas"
    [ApiController] // Indica que o controlador será usado para APIs
    public class DespesasController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        public DespesasController(MeuDbContext context)
        {
            _context = context; // Injeta o contexto no controlador
        }

        // Retorna todas as despesas, incluindo os dados do fornecedor associado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesa>>> GetDespesas()
        {
            return await _context.tb_Despesa.Include(d => d.Fornecedor).ToListAsync();
        }

        // Retorna uma despesa específica com base no ID, incluindo o fornecedor associado
        [HttpGet("{id}")] // Rota: api/Despesas/{id}
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            var despesa = await _context.tb_Despesa
                .Include(d => d.Fornecedor) // Inclui dados do fornecedor
                .FirstOrDefaultAsync(m => m.Id == id); // Busca a despesa pelo ID

            if (despesa == null) // Retorna 404 se a despesa não for encontrada
            {
                return NotFound();
            }
            return despesa; // Retorna a despesa encontrada
        }

        // Renderiza a view com a lista de despesas e seus fornecedores
        [HttpGet("Index")] // Rota: api/Despesas/Index
        public async Task<IActionResult> Index()
        {
            var despesas = await _context.tb_Despesa.Include(d => d.Fornecedor).ToListAsync();
            return View(despesas); // Passa a lista de despesas para a view
        }

        // Renderiza a view com os detalhes de uma despesa específica
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // Verifica se o ID foi informado
            {
                return NotFound();
            }

            var despesa = await _context.tb_Despesa
                .Include(d => d.Fornecedor) // Inclui os dados do fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);

            if (despesa == null) // Retorna 404 se a despesa não for encontrada
            {
                return NotFound();
            }

            return View(despesa); // Retorna a view com os detalhes da despesa
        }

        // Renderiza a view para criar uma nova despesa
        public IActionResult Create()
        {
            return View();
        }

        // Cria uma nova despesa e salva no banco
        [HttpPost]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> Create([Bind("Id,pk_idFornecedor,Tipo,Produto,Quantidade,DRegistro,Valor")] Despesa despesa)
        {
            if (ModelState.IsValid) // Verifica se o modelo é válido
            {
                _context.Add(despesa); // Adiciona a despesa ao contexto
                await _context.SaveChangesAsync(); // Salva as alterações no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de despesas
            }
            return View(despesa); // Retorna à view com os erros de validação
        }

        // Renderiza a view para editar uma despesa existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // Verifica se o ID foi informado
            {
                return NotFound();
            }

            var despesa = await _context.tb_Despesa.FindAsync(id); // Busca a despesa pelo ID
            if (despesa == null) // Retorna 404 se a despesa não for encontrada
            {
                return NotFound();
            }
            return View(despesa); // Retorna a view de edição com os dados da despesa
        }

        // Atualiza uma despesa existente no banco
        [HttpPost]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> Edit(int id, [Bind("Id,pk_idFornecedor,Tipo,Produto,Quantidade,DRegistro,Valor")] Despesa despesa)
        {
            if (id != despesa.Id) // Verifica se o ID informado corresponde à despesa
            {
                return NotFound();
            }

            if (ModelState.IsValid) // Verifica se o modelo é válido
            {
                try
                {
                    _context.Update(despesa); // Marca a despesa como modificada
                    await _context.SaveChangesAsync(); // Salva as alterações
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.Id)) // Verifica se a despesa ainda existe
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Relança a exceção em caso de erro
                    }
                }
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de despesas
            }
            return View(despesa); // Retorna à view com os erros de validação
        }

        // Renderiza a view de confirmação para deletar uma despesa
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // Verifica se o ID foi informado
            {
                return NotFound();
            }

            var despesa = await _context.tb_Despesa
                .Include(d => d.Fornecedor) // Inclui os dados do fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);

            if (despesa == null) // Retorna 404 se a despesa não for encontrada
            {
                return NotFound();
            }

            return View(despesa); // Retorna a view de confirmação
        }

        // Exclui uma despesa existente no banco
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesa = await _context.tb_Despesa.FindAsync(id); // Busca a despesa pelo ID
            if (despesa != null)
            {
                _context.tb_Despesa.Remove(despesa); // Remove a despesa do contexto
                await _context.SaveChangesAsync(); // Salva as alterações
            }
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de despesas
        }

        // Verifica se uma despesa com o ID especificado existe no banco
        private bool DespesaExists(int id)
        {
            return _context.tb_Despesa.Any(e => e.Id == id); // Retorna true se a despesa existir
        }
    }
}
