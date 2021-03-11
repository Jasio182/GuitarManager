using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Player
{
    public class GetPlayersQuery : QueryBase<List<Entities.Player>>
    {
        public override Task<List<Entities.Player>> Execute(GuitarManagerStorageContext context) => context.Players.ToListAsync();
    }
}
