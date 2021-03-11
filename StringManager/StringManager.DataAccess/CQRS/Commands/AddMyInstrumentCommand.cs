using GuitarManager.DataAccess.Entities;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands
{
    public class AddMyInstrumentCommand : CommandBase<MyInstrument, MyInstrument>
    {
        public override async Task<MyInstrument> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
