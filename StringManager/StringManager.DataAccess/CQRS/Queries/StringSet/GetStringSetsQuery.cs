using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringSet
{
    public class GetStringSetsQuery : QueryBase<List<Entities.StringSet>>
    {
        public override Task<List<Entities.StringSet>> Execute(GuitarManagerStorageContext context) => context.StringSets.ToListAsync();
    }
}
