using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Instrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.Instrument;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Instrument
{
    public class AddInstrumentHandler : IRequestHandler<AddInstrumentRequest, AddInstrumentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddInstrumentHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddInstrumentResponse> Handle(AddInstrumentRequest request, CancellationToken cancellationToken)
        {
            var instrument = this.mapper.Map<DataAccess.Entities.Instrument>(request);
            var command = new AddInstrumentCommand()
            {
                Parameter = instrument
            };
            var instrumentFromDb = await this.commandExecutor.Execute(command);
            return new AddInstrumentResponse()
            {
                Data = this.mapper.Map<Domain.Models.Instrument>(instrumentFromDb)
            };
        }
    }
}
