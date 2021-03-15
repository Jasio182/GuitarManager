using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.GuitarType
{
    public class UpdateGuitarTypeCommand : CommandBase<Entities.GuitarType, Entities.GuitarType>
    {
        public override async Task<Entities.GuitarType> Execute(GuitarManagerStorageContext context)
        {
            context.GuitarTypes.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
