using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Instrument
{
    public class GetInstrumentByIdQuery : QueryBase<Entities.Instrument>
    {
        public int Id { get; set; }

        public override Task<Entities.Instrument> Execute(GuitarManagerStorageContext context) => context.Instruments.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
