using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.MyInstrument
{
    public class GetMyInstrumentsQuery : QueryBase<List<Entities.MyInstrument>>
    {
        public override Task<List<Entities.MyInstrument>> Execute(GuitarManagerStorageContext context) => context.MyInstruments.ToListAsync();
    }
}
