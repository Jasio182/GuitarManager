using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StringManager.DataAccess
{
    class StringManagerStorageContextFactory : IDesignTimeDbContextFactory<StringManagerStorageContext>
    {
        public StringManagerStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StringManagerStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-Q60QSH31.\\LOCALSQL;Initial Catalog=StringManagerStorage;Persist Security Info=True;User ID=StringManagerAPI;Password=***********");
            return new StringManagerStorageContext(optionsBuilder.Options);
        }
    }
}
