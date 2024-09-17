using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    // Aqui esta o mapeamento (AppDbContext) do banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
