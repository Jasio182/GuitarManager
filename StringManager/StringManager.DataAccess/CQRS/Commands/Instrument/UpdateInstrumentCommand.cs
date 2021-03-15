using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.Instrument
{
    public class UpdateInstrumentCommand : CommandBase<Entities.Instrument, Entities.Instrument>
    {
        public override async Task<Entities.Instrument> Execute(GuitarManagerStorageContext context)
        {
            context.Instruments.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
