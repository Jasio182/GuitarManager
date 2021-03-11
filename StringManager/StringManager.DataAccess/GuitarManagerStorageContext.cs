using GuitarManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarManager.DataAccess
{
    public class GuitarManagerStorageContext : DbContext
    {
        public GuitarManagerStorageContext(DbContextOptions<GuitarManagerStorageContext> opt) : base(opt) { }

        public DbSet<Instrument> Instruments { get; set; }

        public DbSet<GuitarManufacturer> GuitarManufacturers { get; set; }

        public DbSet<GuitarType> GuitarTypes { get; set; }

        public DbSet<InstalledString> InstalledStrings { get; set; }

        public DbSet<MyInstrument> MyInstruments { get; set; }

        public DbSet<Sound> Sounds { get; set; }

        public DbSet<String> Strings { get; set; }

        public DbSet<StringInSet> StringsInSets { get; set; }

        public DbSet<StringManufacturer> StringManufacturers { get; set; }

        public DbSet<StringSet> StringSets { get; set; }

        public DbSet<StringType> StringTypes { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
