using System; // Tipos básicos e funcionalidades gerais
using System.Collections.Generic; // Manipulação de listas genéricas
using System.Linq; // Consultas LINQ
using System.Threading.Tasks; // Funcionalidades assíncronas
using Microsoft.AspNetCore.Authorization; // Para aplicar o atributo [Authorize]
using Microsoft.AspNetCore.Mvc; // Para criar controladores e ações
using Microsoft.EntityFrameworkCore; // Para interagir com o banco de dados usando Entity Framework
using Web.Models; // Namespace contendo os modelos da aplicação

namespace Web.Controllers
{
    [Authorize] // Exige autenticação para todas as ações deste controlador
    [Route("api/[controller]")] // Define a rota base como "api/Estoques"
    [ApiController] // Indica que o controlador será usado como API
    public class EstoquesController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        public EstoquesController(MeuDbContext context)
        {
            _context = context; // Injeta o contexto do banco de dados no controlador
        }

        // Retorna todos os estoques como JSON
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoques()
        {
            return await _context.tb_Estoque.ToListAsync();
        }

        // Retorna um estoque específico por ID como JSON
        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetEstoque(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);

            if (estoque == null) // Se não encontrado, retorna 404
            {
                return NotFound();
            }

            return estoque; // Retorna o estoque encontrado
        }

        // Renderiza a view de listagem de estoques
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.tb_Estoque.ToListAsync());
        }

        // Renderiza a view de detalhes de um estoque específico
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // Se ID não for fornecido, retorna 404
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque.FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null) // Se não encontrado, retorna 404
            {
                return NotFound();
            }

            return View(estoque); // Renderiza a view com os detalhes do estoque
        }

        // Renderiza a view para criar um novo estoque
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View();
        }

        // Cria um novo estoque e salva no banco
        [HttpPost("create")]
        [ValidateAntiForgeryToken] // Proteção contra CSRF
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,DColheita,DRegistroProducao,EstimativaProducao,Validade,ValorNutritivo,Preco,Situacao")] Estoque estoque)
        {
            if (ModelState.IsValid) // Verifica se o modelo está válido
            {
                _context.Add(estoque); // Adiciona o estoque ao contexto
                await _context.SaveChangesAsync(); // Salva no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a listagem
            }
            return View(estoque); // Retorna à view com erros de validação
        }

        // Renderiza a view para editar um estoque existente
        [HttpGet("view/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // Se ID não for fornecido, retorna 404
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque == null) // Se não encontrado, retorna 404
            {
                return NotFound();
            }
            return View(estoque); // Renderiza a view de edição
        }

        // Atualiza os dados de um estoque existente
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken] // Proteção contra CSRF
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,DColheita,DRegistroProducao,EstimativaProducao,Validade,ValorNutritivo,Preco,Situacao")] Estoque estoque)
        {
            if (id != estoque.Id) // Verifica se o ID corresponde ao estoque
            {
                return BadRequest(); // Retorna erro 400 (Bad Request)
            }

            if (ModelState.IsValid) // Verifica se o modelo está válido
            {
                try
                {
                    _context.Update(estoque); // Marca o estoque como atualizado
                    await _context.SaveChangesAsync(); // Salva no banco
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.Id)) // Verifica se o estoque ainda existe
                    {
                        return NotFound(); // Retorna 404 se não existir
                    }
                    else
                    {
                        throw; // Relança a exceção
                    }
                }
                return RedirectToAction(nameof(Index)); // Redireciona para a listagem
            }
            return View(estoque); // Retorna à view com erros de validação
        }

        // Renderiza a view de confirmação de exclusão
        [HttpGet("view/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // Se ID não for fornecido, retorna 404
            {
                return NotFound();
            }

            var estoque = await _context.tb_Estoque.FirstOrDefaultAsync(m => m.Id == id);
            if (estoque == null) // Se não encontrado, retorna 404
            {
                return NotFound();
            }

            return View(estoque); // Renderiza a view de exclusão
        }

        // Exclui um estoque específico do banco
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken] // Proteção contra CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque != null) // Verifica se o estoque existe
            {
                _context.tb_Estoque.Remove(estoque); // Remove o estoque
                await _context.SaveChangesAsync(); // Salva as alterações
            }

            return RedirectToAction(nameof(Index)); // Redireciona para a listagem
        }

        // Cria um novo estoque via API JSON
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostEstoque([FromBody] Estoque estoque)
        {
            if (ModelState.IsValid) // Verifica se o modelo está válido
            {
                _context.tb_Estoque.Add(estoque); // Adiciona o estoque
                await _context.SaveChangesAsync(); // Salva no banco
                return CreatedAtAction(nameof(GetEstoque), new { id = estoque.Id }, estoque); // Retorna 201 (Created)
            }
            return BadRequest(ModelState); // Retorna 400 (Bad Request)
        }

        // Atualiza um estoque existente via API JSON
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int id, [FromBody] Estoque estoque)
        {
            if (id != estoque.Id) // Verifica se o ID corresponde
            {
                return BadRequest(); // Retorna erro 400 (Bad Request)
            }

            _context.Entry(estoque).State = EntityState.Modified; // Marca o estado como modificado

            try
            {
                await _context.SaveChangesAsync(); // Salva no banco
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id)) // Verifica se o estoque ainda existe
                {
                    return NotFound(); // Retorna 404 se não existir
                }
                else
                {
                    throw; // Relança a exceção
                }
            }

            return NoContent(); // Retorna 204 (No Content)
        }

        // Exclui um estoque via API JSON
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstoque(int id)
        {
            var estoque = await _context.tb_Estoque.FindAsync(id);
            if (estoque == null) // Verifica se o estoque existe
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            _context.tb_Estoque.Remove(estoque); // Remove o estoque
            await _context.SaveChangesAsync(); // Salva as alterações

            return NoContent(); // Retorna 204 (No Content)
        }

        // Verifica se um estoque com o ID fornecido existe no banco
        private bool EstoqueExists(int id)
        {
            return _context.tb_Estoque.Any(e => e.Id == id);
        }
    }
}
