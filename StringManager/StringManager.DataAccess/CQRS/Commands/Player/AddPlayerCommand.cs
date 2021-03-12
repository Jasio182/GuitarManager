using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.Player
{
    public class AddPlayerCommand : CommandBase<Entities.Player, Entities.Player>
    {
        public override async Task<Entities.Player> Execute(GuitarManagerStorageContext context)
        {
            await context.Players.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
