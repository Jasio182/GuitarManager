using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.GuitarManufacturer
{
    public class UpdateGuitarManufacturerCommand : CommandBase<Entities.GuitarManufacturer, Entities.GuitarManufacturer>
    {
        public override async Task<Entities.GuitarManufacturer> Execute(GuitarManagerStorageContext context)
        {
            context.GuitarManufacturers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
