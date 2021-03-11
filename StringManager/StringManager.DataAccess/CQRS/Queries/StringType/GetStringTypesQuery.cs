using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringType
{
    public class GetStringTypesQuery : QueryBase<List<Entities.StringType>>
    {
        public override Task<List<Entities.StringType>> Execute(GuitarManagerStorageContext context) => context.StringTypes.ToListAsync();
    }
}
