using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

public class ProjetoWebContext : IdentityDbContext // Mudança de DbContext para IdentityDbContext
{
    // Construtor do DbContext
    public ProjetoWebContext(DbContextOptions<ProjetoWebContext> options)
        : base(options)
    {
    }

    // DbSet para suas entidades de funcionários (Funcionario e subclasses)
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Jardineiro> Jardineiros { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Financeiro> Financeiros { get; set; }
    public DbSet<Master> Master { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    // Configurações adicionais para os modelos, se necessário
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aqui você pode adicionar configurações de mapeamento ou restrições (opcional)
    }

    public DbSet<ProjetoWeb.Models.Produto> Produto { get; set; } = default!;
}
