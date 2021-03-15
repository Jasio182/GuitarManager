using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.InstalledString
{
    public class GetInstalledStringByPositionAndMyInstrumentQuery : QueryBase<Entities.InstalledString>
    {
        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }
        public override async Task<Entities.InstalledString> Execute(GuitarManagerStorageContext context) =>
           await context.InstalledStrings.FirstOrDefaultAsync(x => x.StringPosition == this.StringPosition && x.MyInstrumentID == this.MyInstrumentID);
    }
}
