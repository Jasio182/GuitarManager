using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetAccountsHandler : IRequestHandler<GetAccountsRequest, GetAccountsResponse>
    {
        private readonly IRepository<Account> accountRepository;
        private readonly IMapper mapper;

        public GetAccountsHandler(IRepository<Account> accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public Task<GetAccountsResponse> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = this.accountRepository.GetAll();
            var mappedAccounts = this.mapper.Map<List<Domain.Models.Account>>(accounts);
            var response = new GetAccountsResponse()
            {
                Data = mappedAccounts
            };
            return Task.FromResult(response);
        }
    }
}
