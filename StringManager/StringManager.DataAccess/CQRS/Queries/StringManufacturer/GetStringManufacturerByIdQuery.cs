using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.StringManufacturer
{
    public class GetStringManufacturerByIdQuery : QueryBase<Entities.StringManufacturer>
    {
        public int Id { get; set; }

        public override async Task<Entities.StringManufacturer> Execute(GuitarManagerStorageContext context) 
            => await context.StringManufacturers.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
