using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.InstalledString
{
    public class RemoveInstalledStringCommand : CommandBase<Entities.InstalledString, Entities.InstalledString>
    {
        public override async Task<Entities.InstalledString> Execute(GuitarManagerStorageContext context)
        {
            context.Remove(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
