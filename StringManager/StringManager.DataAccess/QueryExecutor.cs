using GuitarManager.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly GuitarManagerStorageContext context;

        public QueryExecutor(GuitarManagerStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query) => query.Execute(this.context);
    }
}
