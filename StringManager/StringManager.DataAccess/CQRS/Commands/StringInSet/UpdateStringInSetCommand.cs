using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringInSet
{
    public class UpdateStringInSetCommand : CommandBase<Entities.StringInSet, Entities.StringInSet>
    {
        public override async Task<Entities.StringInSet> Execute(GuitarManagerStorageContext context)
        {
            context.StringsInSets.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
