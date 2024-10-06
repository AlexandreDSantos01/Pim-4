using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

public class ProjetoWebContext : IdentityDbContext
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurando o relacionamento entre Fornecedor e Produto
        modelBuilder.Entity<Fornecedor>()
            .HasMany(f => f.Produtos) // Um fornecedor tem muitos produtos
            .WithOne(p => p.Fornecedor) // Cada produto pertence a um fornecedor
            .HasForeignKey(p => p.FornecedorId); // Define a chave estrangeira

        // Outras configurações podem ser adicionadas aqui, se necessário
    }
}
