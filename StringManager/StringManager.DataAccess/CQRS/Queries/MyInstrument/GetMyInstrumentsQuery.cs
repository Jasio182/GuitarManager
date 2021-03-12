using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.MyInstrument
{
    public class GetMyInstrumentsQuery : QueryBase<List<Entities.MyInstrument>>
    {
        public int PlayerID { get; set; }
        public override Task<List<Entities.MyInstrument>> Execute(GuitarManagerStorageContext context)
        {
            if (PlayerID <= 0)
                return context.MyInstruments.ToListAsync();
            else
                return context.MyInstruments.Where(x => x.PlayerID == this.PlayerID).ToListAsync();
        }
    }
}
