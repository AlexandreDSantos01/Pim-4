using System; // Importa funcionalidades básicas do C#
using System.Collections.Generic; // Importa recursos para listas genéricas
using System.Linq; // Suporte para consultas LINQ
using System.Threading.Tasks; // Suporte a programação assíncrona
using Microsoft.AspNetCore.Authorization; // Necessário para o atributo [Authorize]
using Microsoft.AspNetCore.Mvc; // Suporte para criação de controladores e ações
using Microsoft.EntityFrameworkCore; // Usado para interagir com o banco de dados usando Entity Framework
using Web.Models; // Namespace onde estão os modelos da aplicação

namespace Web.Controllers
{
    [Authorize] // Requer autenticação para acessar qualquer ação deste controlador
    [Route("api/[controller]")] // Define a rota base como "api/Financeiros"
    [ApiController] // Indica que o controlador será usado como API
    public class FinanceirosController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        public FinanceirosController(MeuDbContext context)
        {
            _context = context; // Injeta o contexto no controlador
        }

        // Renderiza a lista de registros financeiros como uma página HTML
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            // Busca todos os registros financeiros do banco e os passa para a view
            return View(await _context.tb_Financeiro.ToListAsync());
        }

        // Retorna todos os registros financeiros como JSON (API)
        [HttpGet]
        public async Task<IActionResult> GetFinanceirosJson()
        {
            var financeiros = await _context.tb_Financeiro.ToListAsync();
            return Json(financeiros); // Converte os dados para JSON e retorna
        }

        // Renderiza os detalhes de um registro financeiro específico como HTML
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // Verifica se o ID foi fornecido
            {
                return NotFound(); // Retorna 404 (Não encontrado) se o ID for nulo
            }

            var financeiro = await _context.tb_Financeiro
                .FirstOrDefaultAsync(m => m.Id == id); // Busca o registro financeiro pelo ID
            if (financeiro == null) // Verifica se o registro foi encontrado
            {
                return NotFound(); // Retorna 404 se não for encontrado
            }

            return View(financeiro); // Retorna a view com os detalhes do registro
        }

        // Retorna os detalhes de um registro financeiro específico como JSON (API)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinanceiroJson(int id)
        {
            var financeiro = await _context.tb_Financeiro.FindAsync(id); // Busca o registro financeiro pelo ID
            if (financeiro == null) // Verifica se o registro foi encontrado
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            return Json(financeiro); // Retorna os detalhes no formato JSON
        }

        // Cria um novo registro financeiro via formulário HTML
        [HttpPost("create")]
        [ValidateAntiForgeryToken] // Protege contra ataques CSRF
        public async Task<IActionResult> Create([Bind("Id,DRegistro,DiaInicio,DiaFim,ValorVenda,ValorDespesa,ValorLucro")] Financeiro financeiro)
        {
            if (ModelState.IsValid) // Verifica se o modelo é válido
            {
                _context.Add(financeiro); // Adiciona o novo registro ao contexto
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
                return RedirectToAction(nameof(Index)); // Redireciona para a listagem
            }
            return View(financeiro); // Retorna à view com erros de validação, se houver
        }

        // Cria um novo registro financeiro via API JSON
        [HttpPost]
        public async Task<IActionResult> PostFinanceiroJson([FromBody] Financeiro financeiro)
        {
            if (ModelState.IsValid) // Verifica se o modelo é válido
            {
                _context.tb_Financeiro.Add(financeiro); // Adiciona o novo registro ao contexto
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
                return CreatedAtAction(nameof(GetFinanceiroJson), new { id = financeiro.Id }, financeiro); // Retorna 201 (Created) com os dados
            }
            return BadRequest(ModelState); // Retorna 400 (Bad Request) se o modelo for inválido
        }

        // Atualiza um registro financeiro existente via API JSON
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceiroJson(int id, [FromBody] Financeiro financeiro)
        {
            if (id != financeiro.Id) // Verifica se o ID corresponde ao registro
            {
                return BadRequest(); // Retorna 400 (Bad Request) se os IDs não coincidirem
            }

            _context.Entry(financeiro).State = EntityState.Modified; // Marca o registro como modificado

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceiroExists(id)) // Verifica se o registro ainda existe
                {
                    return NotFound(); // Retorna 404 se o registro não existir mais
                }
                else
                {
                    throw; // Relança a exceção em caso de outros erros
                }
            }

            return NoContent(); // Retorna 204 (No Content) se a atualização for bem-sucedida
        }

        // Exclui um registro financeiro via API JSON
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceiroJson(int id)
        {
            var financeiro = await _context.tb_Financeiro.FindAsync(id); // Busca o registro financeiro pelo ID
            if (financeiro == null) // Verifica se o registro foi encontrado
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            _context.tb_Financeiro.Remove(financeiro); // Remove o registro do contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return NoContent(); // Retorna 204 (No Content) se a exclusão for bem-sucedida
        }

        // Verifica se um registro financeiro existe no banco de dados
        private bool FinanceiroExists(int id)
        {
            return _context.tb_Financeiro.Any(e => e.Id == id); // Retorna true se o registro existir
        }
    }
}
