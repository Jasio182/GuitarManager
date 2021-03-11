using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.InstalledString
{
    public class GetInstalledStringsQuery : QueryBase<List<Entities.InstalledString>>
    {
        public override Task<List<Entities.InstalledString>> Execute(GuitarManagerStorageContext context) => context.InstalledStrings.ToListAsync();
    }
}
