using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringInSet
{
    public class GetStringInSetByStringSetAndPositionQuery : QueryBase<Entities.StringInSet>
    {
        public int StringPosition { get; set; }

        public int StringSetID { get; set; }

        public override Task<Entities.StringInSet> Execute(GuitarManagerStorageContext context)
            => context.StringsInSets.FirstOrDefaultAsync(x => x.StringPosition == StringPosition && x.StringSetID == StringSetID);
    }
}
