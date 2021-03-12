using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.String
{
    public class AddStringCommand : CommandBase<Entities.String, Entities.String>
    {
        public override async Task<Entities.String> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
