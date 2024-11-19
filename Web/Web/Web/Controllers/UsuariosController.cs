using System; // Namespace básico do .NET
using System.Collections.Generic; // Necessário para manipulação de coleções
using System.Linq; // Usado para consultas LINQ
using System.Threading.Tasks; // Permite uso de métodos assíncronos
using Microsoft.AspNetCore.Authorization; // Usado para aplicar políticas de autenticação
using Microsoft.AspNetCore.Mvc; // Fornece funcionalidades para controladores e ações
using Microsoft.EntityFrameworkCore; // Necessário para interações com o banco de dados
using Web.Models; // Namespace que contém os modelos da aplicação

namespace Web.Controllers
{
    // Controlador protegido, exige autenticação para acessar as ações
    [Authorize]
    [Route("api/[controller]")] // Define a rota base como "api/Usuarios"
    [ApiController] // Identifica este controlador como um API Controller
    public class UsuariosController : Controller
    {
        private readonly MeuDbContext _context; // Contexto do banco de dados

        // Construtor que injeta o contexto do banco de dados
        public UsuariosController(MeuDbContext context)
        {
            _context = context;
        }

        // Retorna todos os usuários em formato JSON
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.tb_Usuario.ToListAsync(); // Busca todos os usuários no banco
        }

        // Retorna um usuário específico em formato JSON
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.tb_Usuario.FindAsync(id); // Busca um usuário pelo ID

            if (usuario == null)
            {
                return NotFound(); // Retorna 404 caso o usuário não seja encontrado
            }

            return usuario; // Retorna o usuário encontrado
        }

        // Retorna a lista de usuários para ser exibida em uma view (HTML)
        [HttpGet("view")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.tb_Usuario.ToListAsync()); // Passa os dados para a view
        }

        // Exibe os detalhes de um usuário específico na view (HTML)
        [HttpGet("view/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 caso o ID não seja fornecido
            }

            var usuario = await _context.tb_Usuario.FirstOrDefaultAsync(m => m.Id == id); // Busca o usuário
            if (usuario == null)
            {
                return NotFound(); // Retorna 404 caso o usuário não seja encontrado
            }

            return View(usuario); // Retorna a view com os detalhes do usuário
        }

        // Exibe o formulário de criação de um novo usuário (HTML)
        [HttpGet("view/create")]
        public IActionResult Create()
        {
            return View(); // Retorna a view de criação
        }

        // Processa a criação de um novo usuário (HTML)
        [HttpPost("create")]
        [ValidateAntiForgeryToken] // Proteção contra CSRF
        public async Task<IActionResult> Create([Bind("Id,Cpf,Nome,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,TipoUsuario,Situacao,Ulogar,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid) // Verifica se os dados são válidos
            {
                _context.Add(usuario); // Adiciona o usuário ao banco de dados
                await _context.SaveChangesAsync(); // Salva as alterações
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de usuários
            }
            return View(usuario); // Retorna à view caso os dados sejam inválidos
        }

        // Exibe o formulário de edição de um usuário específico (HTML)
        [HttpGet("view/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 caso o ID não seja fornecido
            }

            var usuario = await _context.tb_Usuario.FindAsync(id); // Busca o usuário pelo ID
            if (usuario == null)
            {
                return NotFound(); // Retorna 404 caso o usuário não seja encontrado
            }
            return View(usuario); // Retorna a view de edição
        }

        // Processa a edição de um usuário (HTML)
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,Nome,Telefone,Email,Rua,NRua,Bairro,Cidade,Estado,Cep,TipoUsuario,Situacao,Ulogar,Senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound(); // Retorna 404 caso os IDs não coincidam
            }

            if (ModelState.IsValid) // Verifica se os dados são válidos
            {
                try
                {
                    _context.Update(usuario); // Atualiza o usuário no banco de dados
                    await _context.SaveChangesAsync(); // Salva as alterações
                }
                catch (DbUpdateConcurrencyException) // Trata possíveis conflitos de atualização
                {
                    if (!UsuarioExists(usuario.Id)) // Verifica se o usuário existe
                    {
                        return NotFound(); // Retorna 404 caso o usuário não seja encontrado
                    }
                    else
                    {
                        throw; // Relança a exceção
                    }
                }
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de usuários
            }
            return View(usuario); // Retorna à view caso os dados sejam inválidos
        }

        // Exibe o formulário para confirmação de exclusão de um usuário (HTML)
        [HttpGet("view/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna 404 caso o ID não seja fornecido
            }

            var usuario = await _context.tb_Usuario.FirstOrDefaultAsync(m => m.Id == id); // Busca o usuário
            if (usuario == null)
            {
                return NotFound(); // Retorna 404 caso o usuário não seja encontrado
            }

            return View(usuario); // Retorna a view de confirmação de exclusão
        }

        // Processa a exclusão de um usuário (HTML)
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.tb_Usuario.FindAsync(id); // Busca o usuário pelo ID
            if (usuario != null)
            {
                _context.tb_Usuario.Remove(usuario); // Remove o usuário do banco de dados
                await _context.SaveChangesAsync(); // Salva as alterações
            }

            return RedirectToAction(nameof(Index)); // Redireciona para a lista de usuários
        }

        // Método auxiliar para verificar se um usuário existe no banco
        private bool UsuarioExists(int id)
        {
            return _context.tb_Usuario.Any(e => e.Id == id); // Retorna true se o usuário existir
        }
    }
}
