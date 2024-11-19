using System; // Namespace padrão para funcionalidades básicas
using System.Collections.Generic; // Usado para listas e coleções
using System.Linq; // Fornece consultas LINQ para coleções
using System.Threading.Tasks; // Permite programação assíncrona
using Microsoft.AspNetCore.Authorization; // Necessário para o atributo [Authorize]
using Microsoft.AspNetCore.Mvc; // Fornece suporte para criar controladores e ações
using Microsoft.EntityFrameworkCore; // Necessário para trabalhar com EF Core e consultas ao banco de dados
using Web.Models; // Namespace contendo os modelos do sistema

namespace Web.Controllers
{
    [Authorize] // Protege todas as ações deste controlador, exigindo autenticação
    [Route("api/[controller]")] // Define a rota base como "api/Producoes"
    [ApiController] // Identifica este controlador como um API Controller, otimizando a manipulação de dados
    public class ProducoesController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        // Construtor que injeta o contexto do banco de dados
        public ProducoesController(MeuDbContext context)
        {
            _context = context;
        }

        // Retorna todas as produções em formato JSON (API)
        // Método assíncrono para melhor performance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producao>>> GetProducoes()
        {
            return await _context.tb_Producao.ToListAsync(); // Consulta todas as produções no banco
        }

        // Retorna uma produção específica em formato JSON (API)
        [HttpGet("{id}")]
        public async Task<ActionResult<Producao>> GetProducao(int id)
        {
            var producao = await _context.tb_Producao.FindAsync(id); // Busca uma produção pelo ID

            if (producao == null)
            {
                return NotFound(); // Retorna 404 caso não encontre
            }

            return producao; // Retorna a produção encontrada
        }

        // Retorna uma lista de produções para a view (HTML)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            var producoes = await _context.tb_Producao.ToListAsync(); // Busca todas as produções
            return View(producoes); // Retorna a view com os dados
        }

        // Retorna detalhes de uma produção específica para a view (HTML)
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 se o ID for nulo
            }

            var producao = await _context.tb_Producao.FirstOrDefaultAsync(m => m.Id == id); // Busca a produção pelo ID
            if (producao == null)
            {
                return NotFound(); // Retorna 404 caso não encontre
            }

            return View(producao); // Retorna a view com os detalhes
        }

        // Exibe o formulário para criar uma nova produção (HTML)
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View(); // Retorna a view de criação
        }

        // Processa a criação de uma nova produção (HTML)
        [HttpPost("create")]
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,DRegistro,Estimativa")] Producao producao)
        {
            if (ModelState.IsValid) // Valida o modelo
            {
                _context.Add(producao); // Adiciona a nova produção
                await _context.SaveChangesAsync(); // Salva no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a lista
            }
            return View(producao); // Retorna a view com os dados preenchidos em caso de erro
        }

        // Cria uma nova produção via API (JSON)
        [HttpPost]
        public async Task<IActionResult> PostProducao([FromBody] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.tb_Producao.Add(producao); // Adiciona a produção ao banco
                await _context.SaveChangesAsync(); // Salva as alterações
                return CreatedAtAction(nameof(GetProducao), new { id = producao.Id }, producao); // Retorna o status 201
            }
            return BadRequest(ModelState); // Retorna erro 400 em caso de falha de validação
        }

        // Atualiza uma produção existente via API (JSON)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducao(int id, [FromBody] Producao producao)
        {
            if (id != producao.Id)
            {
                return BadRequest(); // Retorna 400 se os IDs não coincidirem
            }

            _context.Entry(producao).State = EntityState.Modified; // Marca o objeto como modificado

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações
            }
            catch (DbUpdateConcurrencyException) // Trata conflitos de atualização
            {
                if (!ProducaoExists(id)) // Verifica se a produção existe
                {
                    return NotFound(); // Retorna 404 se não encontrar
                }
                else
                {
                    throw; // Relança a exceção para tratamento mais amplo
                }
            }

            return NoContent(); // Retorna 204 em caso de sucesso
        }

        // Deleta uma produção via API (JSON)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducao(int id)
        {
            var producao = await _context.tb_Producao.FindAsync(id); // Busca a produção pelo ID
            if (producao == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }

            _context.tb_Producao.Remove(producao); // Remove a produção do banco
            await _context.SaveChangesAsync(); // Salva as alterações

            return NoContent(); // Retorna 204 em caso de sucesso
        }

        // Verifica se uma produção existe no banco
        private bool ProducaoExists(int id)
        {
            return _context.tb_Producao.Any(e => e.Id == id); // Retorna verdadeiro se encontrar
        }
    }
}
