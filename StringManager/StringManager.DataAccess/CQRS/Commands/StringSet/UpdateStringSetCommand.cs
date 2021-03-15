using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringSet
{
    public class UpdateStringSetCommand : CommandBase<Entities.StringSet, Entities.StringSet>
    {
        public override async Task<Entities.StringSet> Execute(GuitarManagerStorageContext context)
        {
            context.StringSets.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
