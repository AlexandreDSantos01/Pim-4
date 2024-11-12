using ApiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using ApiWeb.Data;
using Microsoft.AspNetCore.Identity.Data;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Verifica se o usuário existe
            var usuario = _context.tb_Usuario.SingleOrDefault(u => u.Ulogar == loginModel.Ulogar);

            if (usuario == null)
            {
                return Unauthorized("Usuário não encontrado");
            }

            // Verifica se a senha está correta
            if (!BCrypt.Net.BCrypt.EnhancedVerify(loginModel.Senha, usuario.Senha))
            {
                return Unauthorized("Senha inválida");
            }

            // Cria o JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Ulogar),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                // Adicione outras claims conforme necessário
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }

    // Modelo para as credenciais de login
    public class LoginModel
    {
        public string Ulogar { get; set; }
        public string Senha { get; set; }
    }
}
