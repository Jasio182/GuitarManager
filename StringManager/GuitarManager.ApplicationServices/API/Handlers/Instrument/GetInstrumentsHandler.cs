using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Instrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.Instrument;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetInstrumentsHandler : IRequestHandler<GetInstrumentsRequest, GetInstrumentsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInstrumentsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }


        public async Task<GetInstrumentsResponse> Handle(GetInstrumentsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstrumentsQuery()
            {
                GuitarManufacturerID = request.GuitarManufacturerID,
                GuitarTypeID = request.GuitarTypeID
            };
            var instruments = await this.queryExecutor.Execute(query);
            var mappedInstruments = this.mapper.Map<List<Domain.Models.Instrument>>(instruments);
            var response = new GetInstrumentsResponse()
            {
                Data = mappedInstruments
            };
            return response;
        }
    }
}
