using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries
{
    public abstract class QueryBase <TResult>
    {
        public abstract Task<TResult> Execute(GuitarManagerStorageContext context);
    }
}
