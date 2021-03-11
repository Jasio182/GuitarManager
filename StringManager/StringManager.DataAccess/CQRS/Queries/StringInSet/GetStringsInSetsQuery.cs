using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringInSet
{
    public class GetStringsInSetsQuery : QueryBase<List<Entities.StringInSet>>
    {
        public override Task<List<Entities.StringInSet>> Execute(GuitarManagerStorageContext context) => context.StringsInSets.ToListAsync();
    }
}
