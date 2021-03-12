using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringInSet
{
    public class AddStringInSetCommand : CommandBase<Entities.StringInSet, Entities.StringInSet>
    {
        public override async Task<Entities.StringInSet> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
