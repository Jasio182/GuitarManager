using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Sound
{
    public class GetSoundsQuery : QueryBase<List<Entities.Sound>>
    {
        public override Task<List<Entities.Sound>> Execute(GuitarManagerStorageContext context) => context.Sounds.ToListAsync();
    }
}
