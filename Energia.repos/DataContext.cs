using Energia1.domain;
using Microsoft.EntityFrameworkCore;

namespace Energia1.repos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opcoes) : base(opcoes)
        {
            
        }
        public DbSet<Energia> consumo { get; set; }
        public DbSet<Cliente> cliente { get; set; }
    }
}