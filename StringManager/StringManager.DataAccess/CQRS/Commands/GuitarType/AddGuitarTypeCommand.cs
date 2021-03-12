using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Commands.GuitarType
{
    public class AddGuitarTypeCommand : CommandBase<Entities.GuitarType, Entities.GuitarType>
    {
        public override async Task<Entities.GuitarType> Execute(GuitarManagerStorageContext context)
        {
            await context.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
