using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Instrument
{
    public class GetInstrumentsQuery : QueryBase<List<Entities.Instrument>>
    {
        public override Task<List<Entities.Instrument>> Execute(GuitarManagerStorageContext context) => context.Instruments.ToListAsync();
    }
}
