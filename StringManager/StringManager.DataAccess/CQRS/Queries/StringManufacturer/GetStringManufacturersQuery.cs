using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringManufacturer
{
    public class GetStringManufacturersQuery : QueryBase<List<Entities.StringManufacturer>>
    {
        public override Task<List<Entities.StringManufacturer>> Execute(GuitarManagerStorageContext context) => context.StringManufacturers.ToListAsync();
    }
}
