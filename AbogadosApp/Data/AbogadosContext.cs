using AbogadosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AbogadosApp.Data
{
    public class AbogadosContext : DbContext
    {
        public AbogadosContext(DbContextOptions<AbogadosContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Asunto> Asuntos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Asunto>().ToTable("Asunto");
        }
    }
}
