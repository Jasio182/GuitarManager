using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GuitarManager.DataAccess
{
    class GuitarManagerStorageContextFactory : IDesignTimeDbContextFactory<GuitarManagerStorageContext>
    {
        public GuitarManagerStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GuitarManagerStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-Q60QSH31.\\LOCALSQL;Initial Catalog=StringManagerStorage;Persist Security Info=True;User ID=StringManagerAPI;Password=Strings");
            return new GuitarManagerStorageContext(optionsBuilder.Options);
        }
    }
}
