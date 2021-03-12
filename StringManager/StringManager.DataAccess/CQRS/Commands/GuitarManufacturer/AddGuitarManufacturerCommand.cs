using System;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.GuitarManufacturer
{
    public class AddGuitarManufacturerCommand : CommandBase<Entities.GuitarManufacturer, Entities.GuitarManufacturer>
    {
        public override async Task<Entities.GuitarManufacturer> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
