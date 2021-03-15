using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringManufacturer
{
    public class UpdateStringManufacturerCommand : CommandBase<Entities.StringManufacturer, Entities.StringManufacturer>
    {
        public override async Task<Entities.StringManufacturer> Execute(GuitarManagerStorageContext context)
        {
            context.StringManufacturers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
