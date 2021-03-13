using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.MyInstrument
{
    public class RemoveMyInstrumentCommand : CommandBase<Entities.MyInstrument, Entities.MyInstrument>
    {
        public override async Task<Entities.MyInstrument> Execute(GuitarManagerStorageContext context)
        {
            context.MyInstruments.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
