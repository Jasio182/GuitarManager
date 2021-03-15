using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.GuitarManufacturer
{
    public class GetGuitarManufacturerByIdQuery : QueryBase<Entities.GuitarManufacturer>
    {
        public int Id { get; set; }
        public override Task<Entities.GuitarManufacturer> Execute(GuitarManagerStorageContext context) => context.GuitarManufacturers.FirstOrDefaultAsync(x => x.Id == Id);
    }
}
