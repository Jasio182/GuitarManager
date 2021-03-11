using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.StringManufacturer;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringManufacturer
{
    public class GetStringManufacturersHandler : IRequestHandler<GetStringManufacturersRequest, GetStringManufacturersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetStringManufacturersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetStringManufacturersResponse> Handle(GetStringManufacturersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringManufacturersQuery();
            var stringManufacturers = await this.queryExecutor.Execute(query);
            var mappedStringManufacturers = mapper.Map<List<Domain.Models.StringManufacturer>>(stringManufacturers);
            var response = new GetStringManufacturersResponse()
            {
                Data = mappedStringManufacturers
            };
            return response;
        }
    }
}
