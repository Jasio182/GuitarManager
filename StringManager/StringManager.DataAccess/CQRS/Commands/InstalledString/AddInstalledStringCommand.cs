using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.InstalledString
{
    public class AddInstalledStringCommand : CommandBase<Entities.InstalledString, Entities.InstalledString>
    {
        public override async Task<Entities.InstalledString> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
