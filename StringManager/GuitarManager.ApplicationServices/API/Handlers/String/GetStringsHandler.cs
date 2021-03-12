using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.String;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.String;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.String
{
    public class GetStringsHandler : IRequestHandler<GetStringsRequest, GetStringsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetStringsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetStringsResponse> Handle(GetStringsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringsQuery() 
            { 
                StringManufacturerID = request.StringManufacturerID,
                StringTypeID = request.StringTypeID
            };
            var strings = await this.queryExecutor.Execute(query);
            var mappedString = mapper.Map<List<Domain.Models.String>>(strings);
            var response = new GetStringsResponse()
            {
                Data = mappedString
            };
            return response;
        }
    }
}
