using GuitarManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries
{
    public class GetSoundQuery : QueryBase<Sound>
    {
        public int Id { get; set; }
        public override async Task<Sound> Execute(GuitarManagerStorageContext context)
        {
            var sound = await context.Sounds.FirstOrDefaultAsync(x => x.Id == this.Id);
            return sound;
        }
    }
}
