using Microsoft.EntityFrameworkCore;

namespace Web.Models
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Usuario> tb_Usuario { get; set; }
        public DbSet<Producao> tb_Producao { get; set; }
        public DbSet<Estoque> tb_Estoque { get; set; }
        public DbSet<Cliente> tb_Cliente { get; set; }
        public DbSet<Fornecedor> tb_Fornecedor { get; set; }
        public DbSet<Despesa> tb_Despesa { get; set; }
        public DbSet<Venda> tb_Venda { get; set; }
        public DbSet<Financeiro> tb_Financeiro { get; set; }
    }
}
