using Microsoft.EntityFrameworkCore;
using StringManager.DataAccess.Entities;

namespace StringManager.DataAccess
{
    class StringManagerStorageContext : DbContext
    {
        public StringManagerStorageContext(DbContextOptions<StringManagerStorageContext> opt) : base(opt)
        {
                
        }
        public DbSet<Instrument> Instruments { get; set; }
    }
}
