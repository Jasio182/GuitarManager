using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.String
{
    public class GetStringByIdQuery : QueryBase<Entities.String>
    {
        public int Id { get; set; }

        public override async Task<Entities.String> Execute(GuitarManagerStorageContext context) => await context.Strings.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
