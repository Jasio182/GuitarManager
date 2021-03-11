using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly GuitarManagerStorageContext context;

        public CommandExecutor(GuitarManagerStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(Commands.CommandBase<TParameters, TResult> command)
        {
            return command.Execute(context);
        }
    }
}
