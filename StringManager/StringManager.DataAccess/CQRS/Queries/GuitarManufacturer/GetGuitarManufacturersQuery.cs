using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.GuitarManufacturer
{
    public class GetGuitarManufacturersQuery : QueryBase<List<Entities.GuitarManufacturer>>
    {
        public override Task<List<Entities.GuitarManufacturer>> Execute(GuitarManagerStorageContext context) => context.GuitarManufacturers.ToListAsync();
    }
}
