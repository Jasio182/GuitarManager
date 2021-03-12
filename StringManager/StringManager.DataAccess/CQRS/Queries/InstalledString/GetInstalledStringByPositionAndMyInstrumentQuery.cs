using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.InstalledString
{
    public class GetInstalledStringByPositionAndMyInstrumentQuery : QueryBase<Entities.InstalledString>
    {
        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }
        public override Task<Entities.InstalledString> Execute(GuitarManagerStorageContext context) =>
            context.InstalledStrings.FirstOrDefaultAsync(x => x.StringPosition == this.StringPosition && x.MyInstrumentID == this.MyInstrumentID);
    }
}
