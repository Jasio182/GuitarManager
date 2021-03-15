using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringType
{
    public class GetStringTypeByIdQuery : QueryBase<Entities.StringType>
    {
        public int Id { get; set; }
        public override async Task<Entities.StringType> Execute(GuitarManagerStorageContext context) => await context.StringTypes.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
