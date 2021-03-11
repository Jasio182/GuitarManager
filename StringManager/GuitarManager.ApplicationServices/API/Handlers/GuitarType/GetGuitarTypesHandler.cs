using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.GuitarType;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.GuitarType;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.GuitarType
{
    public class GetGuitarTypesHandler : IRequestHandler<GetGuitarTypesRequest, GetGuitarTypesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetGuitarTypesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetGuitarTypesResponse> Handle(GetGuitarTypesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGuitarTypesQuery();
            var guitarTypes = await queryExecutor.Execute(query);
            var domainGuitarTypes = mapper.Map<List<Domain.Models.GuitarType>>(guitarTypes);
            var response = new GetGuitarTypesResponse()
            {
                Data = domainGuitarTypes
            };
            return response;
        }
    }
}
