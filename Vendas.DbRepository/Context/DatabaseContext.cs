using Vendas.DbRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vendas.DbRepository.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
