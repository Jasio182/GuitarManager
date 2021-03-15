using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.InstalledString
{
    public class UpdateInstalledStringCommand : CommandBase<Entities.InstalledString, Entities.InstalledString>
    {
        public override async Task<Entities.InstalledString> Execute(GuitarManagerStorageContext context)
        {
            context.InstalledStrings.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
