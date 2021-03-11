using GuitarManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries
{
    public class GetSoundsQuery : QueryBase<List<Sound>>
    {
        public override Task<List<Sound>> Execute(GuitarManagerStorageContext context) => context.Sounds.ToListAsync();
    }
}
