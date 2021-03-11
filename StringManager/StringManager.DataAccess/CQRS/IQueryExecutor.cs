using GuitarManager.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
