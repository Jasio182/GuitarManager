using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.StringSet
{
    public class AddStringSetCommand : CommandBase<Entities.StringSet, Entities.StringSet>
    {
        public override async Task<Entities.StringSet> Execute(GuitarManagerStorageContext context)
        {
            await context.StringSets.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
