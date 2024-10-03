using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models; // O namespace correto do seu DbContext

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner
builder.Services.AddControllersWithViews();

// Configura o contexto do banco de dados com a string de conex�o
builder.Services.AddDbContext<ProjetoWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoWebContext")));

// Configura o Identity para gerenciar usu�rios e autentica��o
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ProjetoWebContext>();

// Configura a aplica��o para usar p�ginas do Razor (opcional se quiser usar p�ginas de login padr�o)
builder.Services.AddRazorPages();

// Configura��o do cookie de autentica��o
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Define a rota de login
});

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ativa a autentica��o e autoriza��o
app.UseAuthentication(); // Necess�rio para login
app.UseAuthorization();

// Mapeia a rota padr�o para a p�gina de login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // Mapeia para a a��o Login do AccountController

// Mapeia as p�ginas do Razor (se estiver usando p�ginas para login/registro)
app.MapRazorPages();

// Inicia a aplica��o
app.Run();
