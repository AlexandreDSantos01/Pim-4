using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Web.Models;  // Certifique-se de que esse namespace esteja correto para o seu projeto
using Web.Services; // Adicione esta linha para importar o namespace do EmailSender

var builder = WebApplication.CreateBuilder(args);

// Configurar o contexto de banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar o Identity com roles (papéis) e IdentityUser
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;  // Altere para false se não precisar de confirmação de conta
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Registrar o EmailSender
builder.Services.AddTransient<IEmailSender, EmailSender>();

// Adicionar as políticas de autorização
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireViewerRole", policy => policy.RequireRole("Viewer"));
});

// Adicionar controladores com visualizações
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();  // Importante para as páginas do Identity

// Criar a aplicação
var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Usar HSTS em produção
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adicionar autenticação e autorização
app.UseAuthentication();  // Sempre adicionar antes de Authorization
app.UseAuthorization();

// Mapear as páginas do Identity (para login, registro, etc.)
app.MapRazorPages(); // Isso é necessário para incluir as páginas de autenticação padrão

// Redireciona para a página de login quando a raiz é acessada
app.MapGet("/", context =>
{
    context.Response.Redirect("/Identity/Account/Login");
    return Task.CompletedTask;
});

// Mapeia as rotas padrões para os controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produtos}/{action=Index}/{id?}"); // Redireciona para Produtos

// Executar a aplicação
app.Run();
