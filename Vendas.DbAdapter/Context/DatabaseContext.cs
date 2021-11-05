using Vendas.DbRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vendas.DbRepository.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Entities.Vendas> Vendas { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
    }
}
