using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringType
{
    public class UpdateStringTypeCommand : CommandBase<Entities.StringType, Entities.StringType>
    {
        public override async Task<Entities.StringType> Execute(GuitarManagerStorageContext context)
        {
            context.StringTypes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
