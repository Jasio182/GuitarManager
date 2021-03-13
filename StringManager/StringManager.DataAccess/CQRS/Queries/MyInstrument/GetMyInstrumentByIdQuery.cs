using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.MyInstrument
{
    public class GetMyInstrumentByIdQuery : QueryBase<Entities.MyInstrument>
    {
        public int Id { get; set; }

        public override Task<Entities.MyInstrument> Execute(GuitarManagerStorageContext context) => context.MyInstruments.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
