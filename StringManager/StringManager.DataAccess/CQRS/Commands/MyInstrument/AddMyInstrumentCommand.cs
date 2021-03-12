using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.MyInstrument
{
    public class AddMyInstrumentCommand : CommandBase<Entities.MyInstrument, Entities.MyInstrument>
    {
        public override async Task<Entities.MyInstrument> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
