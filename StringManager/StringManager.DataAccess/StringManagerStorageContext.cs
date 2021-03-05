using GuitarManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarManager.DataAccess
{
    class StringManagerStorageContext : DbContext
    {
        public StringManagerStorageContext(DbContextOptions<StringManagerStorageContext> opt) : base(opt)
        {

        }
        public DbSet<Instrument> Instruments { get; set; }
    }
}
