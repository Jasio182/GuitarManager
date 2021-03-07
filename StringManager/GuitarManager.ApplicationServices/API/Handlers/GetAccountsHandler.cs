using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetAccountsHandler : IRequestHandler<GetAccountsRequest, GetAccountsResponse>
    {
        private readonly IRepository<Account> accountRepository;

        public GetAccountsHandler(IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Task<GetAccountsResponse> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = this.accountRepository.GetAll();
            var domainAccounts = accounts.Select(x => new Domain.Models.Account()
            {
                Id = x.Id,
                Login = x.Login,
                IsAdmin = x.IsAdmin
            });
            var response = new GetAccountsResponse()
            {
                Data = domainAccounts.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
