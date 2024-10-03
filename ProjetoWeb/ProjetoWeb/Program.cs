using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models; // O namespace correto do seu DbContext

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllersWithViews();

// Configura o contexto do banco de dados com a string de conexão
builder.Services.AddDbContext<ProjetoWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoWebContext")));

// Configura o Identity para gerenciar usuários e autenticação
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ProjetoWebContext>();

// Configura a aplicação para usar páginas do Razor (opcional se quiser usar páginas de login padrão)
builder.Services.AddRazorPages();

// Configuração do cookie de autenticação
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Define a rota de login
});

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ativa a autenticação e autorização
app.UseAuthentication(); // Necessário para login
app.UseAuthorization();

// Mapeia a rota padrão para a página de login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // Mapeia para a ação Login do AccountController

// Mapeia as páginas do Razor (se estiver usando páginas para login/registro)
app.MapRazorPages();

// Inicia a aplicação
app.Run();
