using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Instrument
{
    public class GetInstrumentsQuery : QueryBase<List<Entities.Instrument>>
    {
        public int GuitarTypeID { get; set; }

        public int GuitarManufacturerID { get; set; }

        public override Task<List<Entities.Instrument>> Execute(GuitarManagerStorageContext context)
        {
            if (GuitarTypeID <= 0 && GuitarManufacturerID > 0)
                return context.Instruments.Where(x => x.GuitarManufacturerID == this.GuitarManufacturerID).ToListAsync();
            else if (GuitarTypeID > 0 && GuitarManufacturerID <= 0)
                return context.Instruments.Where(x => x.GuitarTypeID == this.GuitarTypeID).ToListAsync();
            else if (GuitarTypeID > 0 && GuitarManufacturerID > 0)
                return context.Instruments.Where(x => x.GuitarTypeID == this.GuitarTypeID && x.GuitarManufacturerID == this.GuitarManufacturerID).ToListAsync();
            else
                return context.Instruments.ToListAsync();
        }
    }
}
