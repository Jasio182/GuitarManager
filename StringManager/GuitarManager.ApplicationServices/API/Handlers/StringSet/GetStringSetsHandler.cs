using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.StringSet;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringSet
{
    public class GetStringSetsHandler : IRequestHandler<GetStringSetsRequest, GetStringSetsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetStringSetsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetStringSetsResponse> Handle(GetStringSetsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringSetsQuery();
            var stringSets = await this.queryExecutor.Execute(query);
            var mappedStringSets = mapper.Map<List<Domain.Models.StringSet>>(stringSets);
            var response = new GetStringSetsResponse()
            {
                Data = mappedStringSets
            };
            return response;
        }
    }
}
