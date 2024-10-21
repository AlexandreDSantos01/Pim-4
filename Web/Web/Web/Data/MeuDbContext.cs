using Microsoft.EntityFrameworkCore;

namespace Web.Models
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producao> Producao { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Financeiro> Financeiro { get; set; }
    }
}
