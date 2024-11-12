using ApiWeb.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();

// Configura��o do DbContext com a string de conex�o
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o do CORS para permitir qualquer origem, m�todo e cabe�alho
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin() // Permite qualquer origem
            .AllowAnyMethod() // Permite qualquer m�todo (GET, POST, etc.)
            .AllowAnyHeader()); // Permite qualquer cabe�alho
});

// Configura��o do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o da autentica��o JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],  // Seu issuer configurado no appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"],  // Seu audience configurado no appsettings.json
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])) // Chave secreta
        };
    });

// Adiciona o servi�o de autentica��o
builder.Services.AddAuthorization();

var app = builder.Build();

// Configura o middleware de CORS
app.UseCors("AllowAllOrigins"); // Habilita a pol�tica de CORS definida acima

// Configura o middleware de autentica��o e autoriza��o
app.UseAuthentication();  // Adiciona o middleware de autentica��o JWT
app.UseAuthorization();   // Adiciona o middleware de autoriza��o

// Configura o pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
