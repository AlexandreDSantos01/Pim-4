using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models; // Certifique-se de ajustar o namespace para o seu projeto

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Adicione a DbSet para sua entidade de Produto
    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Web.Models.Permissao> Permissao { get; set; } = default!;

    // Configure o modelo com precisão para o campo decimal 'Preco'
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar a precisão e escala para o campo 'Preco' da entidade 'Produto'
        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasColumnType("decimal(18,2)"); // 18 dígitos totais, 2 casas decimais

        // Adicionar papéis ao banco de dados no método OnModelCreating
        SeedRoles(modelBuilder); // Método auxiliar para adicionar papéis
    }

    // Método auxiliar para adicionar os papéis de usuário
    private void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "Viewer", NormalizedName = "VIEWER" }
        );
    }
}
