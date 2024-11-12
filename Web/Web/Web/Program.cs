using Microsoft.EntityFrameworkCore;
using Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controladores com views (MVC)
builder.Services.AddControllersWithViews();

// Configuração do DbContext para conectar ao banco de dados
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDbContext")));

// Configuração de autenticação por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Caminho para a página de login
        options.LogoutPath = "/Account/Logout"; // Caminho para logout, se necessário
        options.AccessDeniedPath = "/Account/AccessDenied"; // Opcional: caminho para acesso negado
        options.Cookie.HttpOnly = true; // Melhora a segurança dos cookies
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Exige HTTPS para cookies
    });

// Configuração do CORS (Cors All Origins) - Permite todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configura o pipeline de tratamento de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona automaticamente para HTTPS
app.UseStaticFiles(); // Habilita arquivos estáticos (CSS, JavaScript, etc.)

app.UseRouting(); // Habilita o roteamento

// Middleware para redirecionar a raiz ("/") para a página de login
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/Account/Login");
        return;
    }
    await next();
});

// Ativa a autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Habilita a política CORS configurada
app.UseCors("AllowAllOrigins");

// Define as rotas padrão da aplicação
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
