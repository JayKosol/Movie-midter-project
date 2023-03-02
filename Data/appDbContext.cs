using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class appDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=movie1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<Movief> Movies { get; set; }
    }
}
