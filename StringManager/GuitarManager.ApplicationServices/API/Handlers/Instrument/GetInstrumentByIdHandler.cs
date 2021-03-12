using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Instrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.Instrument;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Instrument
{
    public class GetInstrumentByIdHandler : IRequestHandler<GetInstrumentByIdRequest, GetInstrumentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetInstrumentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetInstrumentByIdResponse> Handle(GetInstrumentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstrumentByIdQuery()
            {
                Id = request.InstrumentId
            };
            var instrument = await this.queryExecutor.Execute(query);
            var mappedInstrument = this.mapper.Map<Domain.Models.Instrument>(instrument);
            var response = new GetInstrumentByIdResponse()
            {
                Data = mappedInstrument
            };
            return response;
        }
    }
}
