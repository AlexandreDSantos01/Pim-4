using ApiWeb.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
