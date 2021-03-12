using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Sound
{
    public class GetSoundByIdQuery : QueryBase<Entities.Sound>
    {
        public int Id { get; set; }
        public override async Task<Entities.Sound> Execute(GuitarManagerStorageContext context) => await context.Sounds.FirstOrDefaultAsync(x => x.Id == Id);
    }
}
