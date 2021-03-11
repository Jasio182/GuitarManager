using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.GuitarType
{
    public class GetGuitarTypesQuery : QueryBase<List<Entities.GuitarType>>
    {
        public override Task<List<Entities.GuitarType>> Execute(GuitarManagerStorageContext context) => context.GuitarTypes.ToListAsync();
    }
}
