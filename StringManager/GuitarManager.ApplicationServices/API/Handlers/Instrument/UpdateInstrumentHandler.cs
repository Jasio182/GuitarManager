using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Instrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.Instrument;
using GuitarManager.DataAccess.CQRS.Queries.Instrument;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Instrument
{
    class UpdateInstrumentHandler : IRequestHandler<UpdateInstrumentRequest, UpdateInstrumentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateInstrumentHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateInstrumentResponse> Handle(UpdateInstrumentRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstrumentByIdQuery()
            {
                Id = request.instrumentId
            };
            var gotInstrument = await this.queryExecutor.Execute(query);
            if (gotInstrument == null)
                return new UpdateInstrumentResponse()
                {
                    Data = null
                };
            var command = new UpdateInstrumentCommand()
            {
                Parameter = this.mapper.Map(request, gotInstrument)
            };
            var instrument = await this.commandExecutor.Execute(command);
            return new UpdateInstrumentResponse()
            {
                Data = this.mapper.Map<Domain.Models.Instrument>(instrument)
            };
        }
    }
}
