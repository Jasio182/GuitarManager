using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.StringType;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringType
{
    public class GetStringTypesHandler : IRequestHandler<GetStringTypesRequest, GetStringTypesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetStringTypesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetStringTypesResponse> Handle(GetStringTypesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringTypesQuery();
            var stringTypes = await this.queryExecutor.Execute(query);
            var mappedStringTypes = mapper.Map<List<Domain.Models.StringType>>(stringTypes);
            var response = new GetStringTypesResponse()
            {
                Data = mappedStringTypes
            };
            return response;
        }
    }
}
