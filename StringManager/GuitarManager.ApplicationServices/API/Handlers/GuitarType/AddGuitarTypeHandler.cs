using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.GuitarType;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.GuitarType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.GuitarType
{
    class AddGuitarTypeHandler : IRequestHandler<AddGuitarTypeRequest, AddGuitarTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddGuitarTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddGuitarTypeResponse> Handle(AddGuitarTypeRequest request, CancellationToken cancellationToken)
        {
            var guitarType = this.mapper.Map<DataAccess.Entities.GuitarType>(request);
            var command = new AddGuitarTypeCommand()
            {
                Parameter = guitarType
            };
            var guitarTypeFromDb = await this.commandExecutor.Execute(command);
            return new AddGuitarTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.GuitarType>(guitarTypeFromDb)
            };
        }
    }
}
