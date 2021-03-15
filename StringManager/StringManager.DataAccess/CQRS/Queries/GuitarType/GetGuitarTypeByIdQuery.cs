using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.GuitarType
{
    public class GetGuitarTypeByIdQuery : QueryBase<Entities.GuitarType>
    {
        public int Id { get; set; }
        public override Task<Entities.GuitarType> Execute(GuitarManagerStorageContext context) => context.GuitarTypes.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
