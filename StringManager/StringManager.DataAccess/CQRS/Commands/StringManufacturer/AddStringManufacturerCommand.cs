using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringManufacturer
{
    public class AddStringManufacturerCommand : CommandBase<Entities.StringManufacturer, Entities.StringManufacturer>
    {
        public override async Task<Entities.StringManufacturer> Execute(GuitarManagerStorageContext context)
        {
            await context.StringManufacturers.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
