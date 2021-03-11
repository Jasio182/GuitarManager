using GuitarManager.DataAccess.Entities;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands
{
    class AddSoundCommand : CommandBase<Sound, Sound>
    {
        public override async Task<Sound> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
