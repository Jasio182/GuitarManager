using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.Instrument
{
    public class AddInstrumentCommand : CommandBase<Entities.Instrument, Entities.Instrument>
    {
        public override async Task<Entities.Instrument> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
