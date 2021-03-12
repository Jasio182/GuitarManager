using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Player
{
    public class GetPlayerByIdQuery : QueryBase<Entities.Player>
    {
        public int Id { get; set; }

        public override Task<Entities.Player> Execute(GuitarManagerStorageContext context) => context.Players.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
