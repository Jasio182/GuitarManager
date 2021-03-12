using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringType
{
    public class AddStringTypeCommand : CommandBase<Entities.StringType, Entities.StringType>
    {
        public override async Task<Entities.StringType> Execute(GuitarManagerStorageContext context)
        {
            await context.StringTypes.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
