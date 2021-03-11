using GuitarManager.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS
{
    public interface ICommandExecutor 
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
