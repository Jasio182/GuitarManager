using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.String
{
    public class UpdateStringCommand : CommandBase<Entities.String, Entities.String>
    {
        public override async Task<Entities.String> Execute(GuitarManagerStorageContext context)
        {
            context.Strings.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
