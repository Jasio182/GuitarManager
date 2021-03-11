using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.StringInSet;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringInSet
{
    class GetStringsInSetsHandler : IRequestHandler<GetStringsInSetsRequest, GetStringsInSetsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetStringsInSetsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetStringsInSetsResponse> Handle(GetStringsInSetsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringsInSetsQuery();
            var stringInSets = await queryExecutor.Execute(query);
            var mappedStringsInSets = mapper.Map<List<Domain.Models.StringInSet>>(stringInSets);
            var response = new GetStringsInSetsResponse()
            {
                Data = mappedStringsInSets
            };
            return response;
        }
    }
}
