using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AbogadosApp.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AbogadosContext>
    {
        public AbogadosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AbogadosContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-GI1V5TE;Database=AbogadosApp;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AbogadosContext(optionsBuilder.Options);
        }
    }
}
