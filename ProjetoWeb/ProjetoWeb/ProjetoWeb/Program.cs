using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models; // O namespace correto do seu DbContext

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllersWithViews();

// Configura o contexto do banco de dados com a string de conexão
builder.Services.AddDbContext<ProjetoWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoWebContext")));

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

app.UseAuthorization();

// Mapeia a rota padrão para controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplicação
app.Run();
