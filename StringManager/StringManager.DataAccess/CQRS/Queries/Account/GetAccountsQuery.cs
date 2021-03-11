using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuitarManager.DataAccess.CQRS.Queries.Account
{
    public class GetAccountsQuery : QueryBase<List<Entities.Account>>
    {
        public override Task<List<Entities.Account>> Execute(GuitarManagerStorageContext context) => context.Accounts.ToListAsync();
    }
}
