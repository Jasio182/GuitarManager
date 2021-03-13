using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.Player
{
    public class RemovePlayerCommand : CommandBase<Entities.Player, Entities.Player>
    {
        public override async Task<Entities.Player> Execute(GuitarManagerStorageContext context)
        {
            context.Remove(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
