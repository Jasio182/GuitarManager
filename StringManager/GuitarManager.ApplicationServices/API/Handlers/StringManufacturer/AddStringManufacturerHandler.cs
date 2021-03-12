using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringManufacturer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringManufacturer
{
    class AddStringManufacturerHandler : IRequestHandler<AddStringManufacturerRequest, AddStringManufacturerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddStringManufacturerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddStringManufacturerResponse> Handle(AddStringManufacturerRequest request, CancellationToken cancellationToken)
        {
            var stringManufacturer = this.mapper.Map<DataAccess.Entities.StringManufacturer>(request);
            var command = new AddStringManufacturerCommand()
            {
                Parameter = stringManufacturer
            };
            var stringManufacturerFromDb = await this.commandExecutor.Execute(command);
            return new AddStringManufacturerResponse()
            {
                Data = mapper.Map<Domain.Models.StringManufacturer>(stringManufacturerFromDb)
            };
        }
    }
}
