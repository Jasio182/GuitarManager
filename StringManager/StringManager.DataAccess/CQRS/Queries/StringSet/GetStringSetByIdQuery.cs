using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringSet
{
    public class GetStringSetByIdQuery : QueryBase<Entities.StringSet>
    {
        public int Id { get; set; }

        public override Task<Entities.StringSet> Execute(GuitarManagerStorageContext context) => context.StringSets.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
