using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.String
{
    public class GetStringsQuery : QueryBase<List<Entities.String>>
    {
        public int StringTypeID { get; set; }

        public int StringManufacturerID { get; set; }
        public override Task<List<Entities.String>> Execute(GuitarManagerStorageContext context)
        {
            if (StringTypeID <= 0 && StringManufacturerID > 0)
                return context.Strings.Where(x => x.StringManufacturerID == this.StringManufacturerID).ToListAsync();
            else if (StringTypeID > 0 && StringManufacturerID <= 0)
                return context.Strings.Where(x => x.StringTypeID == this.StringTypeID).ToListAsync();
            else if (StringTypeID > 0 && StringManufacturerID > 0)
                return context.Strings.Where(x => x.StringManufacturerID == this.StringManufacturerID && x.StringTypeID == this.StringTypeID).ToListAsync();
            else
                return context.Strings.ToListAsync();
        }
            
    }
}
