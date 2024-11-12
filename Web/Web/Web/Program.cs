using Microsoft.EntityFrameworkCore;
using Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controladores com views (MVC)
builder.Services.AddControllersWithViews();

// Configura��o do DbContext para conectar ao banco de dados
builder.Services.AddDbContext<MeuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDbContext")));

// Configura��o de autentica��o por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Caminho para a p�gina de login
        options.LogoutPath = "/Account/Logout"; // Caminho para logout, se necess�rio
        options.AccessDeniedPath = "/Account/AccessDenied"; // Opcional: caminho para acesso negado
        options.Cookie.HttpOnly = true; // Melhora a seguran�a dos cookies
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Exige HTTPS para cookies
    });

// Configura��o do CORS (Cors All Origins) - Permite todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configura o pipeline de tratamento de requisi��es HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona automaticamente para HTTPS
app.UseStaticFiles(); // Habilita arquivos est�ticos (CSS, JavaScript, etc.)

app.UseRouting(); // Habilita o roteamento

// Middleware para redirecionar a raiz ("/") para a p�gina de login
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/Account/Login");
        return;
    }
    await next();
});

// Ativa a autentica��o e autoriza��o
app.UseAuthentication();
app.UseAuthorization();

// Habilita a pol�tica CORS configurada
app.UseCors("AllowAllOrigins");

// Define as rotas padr�o da aplica��o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
