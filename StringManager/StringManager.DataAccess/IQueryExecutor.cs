using GuitarManager.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess
{
    public interface IQueryExecutor
    {
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
