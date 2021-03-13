using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringInSet
{
    public class RemoveStringInSetCommand : CommandBase<Entities.StringInSet, Entities.StringInSet>
    {
        public override async Task<Entities.StringInSet> Execute(GuitarManagerStorageContext context)
        {
            context.Remove(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
