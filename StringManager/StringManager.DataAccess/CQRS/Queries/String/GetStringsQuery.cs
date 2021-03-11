using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.String
{
    public class GetStringsQuery : QueryBase<List<Entities.String>>
    {
        public override Task<List<Entities.String>> Execute(GuitarManagerStorageContext context) => context.Strings.ToListAsync();
    }
}
