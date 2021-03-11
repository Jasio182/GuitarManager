using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.MyInstrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.MyInstrument
{
    public class AddMyInstrumentHandler : IRequestHandler<AddMyInstrumentRequest, AddMyInstrumentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddMyInstrumentHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddMyInstrumentResponse> Handle(AddMyInstrumentRequest request, CancellationToken cancellationToken)
        {
            var myInstrument = mapper.Map<DataAccess.Entities.MyInstrument>(request);
            var command = new AddMyInstrumentCommand() { Parameter = myInstrument };
            var myInstrumentFromDb = await this.commandExecutor.Execute(command);
            return new AddMyInstrumentResponse()
            {
                Data = mapper.Map<Domain.Models.MyInstrument>(myInstrumentFromDb)
            };
        }
    }
}
