using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Account;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.Account;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Account
{
    public class GetAccountsHandler : IRequestHandler<GetAccountsRequest, GetAccountsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAccountsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAccountsResponse> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAccountsQuery();
            var accounts = await queryExecutor.Execute(query);
            var mappedAccounts = mapper.Map<List<Domain.Models.Account>>(accounts);
            var response = new GetAccountsResponse()
            {
                Data = mappedAccounts
            };
            return response;
        }
    }
}
