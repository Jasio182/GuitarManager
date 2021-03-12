using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.GuitarManufacturer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.GuitarManufacturer
{
    public class AddGuitarManufacturerHandler : IRequestHandler<AddGuitarManufacturerRequest, AddGuitarManufacturerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddGuitarManufacturerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddGuitarManufacturerResponse> Handle(AddGuitarManufacturerRequest request, CancellationToken cancellationToken)
        {
            var guitarManufacturer = this.mapper.Map<DataAccess.Entities.GuitarManufacturer>(request);
            var command = new AddGuitarManufacturerCommand()
            {
                Parameter = guitarManufacturer
            };
            var guitarManufacturerFromDb = await this.commandExecutor.Execute(command);
            return new AddGuitarManufacturerResponse()
            {
                Data = this.mapper.Map<Domain.Models.GuitarManufacturer>(guitarManufacturerFromDb)
            };
        }
    }
}
