using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.GuitarManufacturer;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.GuitarManufacturer
{
    public class GetGuitarManufacturersHandler : IRequestHandler<GetGuitarManufacturersRequest, GetGuitarManufacturersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetGuitarManufacturersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetGuitarManufacturersResponse> Handle(GetGuitarManufacturersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGuitarManufacturersQuery();
            var guitarManufacturers = await queryExecutor.Execute(query);
            var mappedGuitarManufacturers = mapper.Map<List<Domain.Models.GuitarManufacturer>>(guitarManufacturers);
            var response = new GetGuitarManufacturersResponse()
            {
                Data = mappedGuitarManufacturers
            };
            return response;
        }
    }
}
