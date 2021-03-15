using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.MyInstrument
{
    public class UpdateMyInstrumentCommand : CommandBase<Entities.MyInstrument, Entities.MyInstrument>
    {
        public override async Task<Entities.MyInstrument> Execute(GuitarManagerStorageContext context)
        {
            context.MyInstruments.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
