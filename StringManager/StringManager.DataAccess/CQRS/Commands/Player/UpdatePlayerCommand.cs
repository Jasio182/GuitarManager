using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.Player
{
    public class UpdatePlayerCommand : CommandBase<Entities.Player, Entities.Player>
    {
        public override async Task<Entities.Player> Execute(GuitarManagerStorageContext context)
        {
            context.Players.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
