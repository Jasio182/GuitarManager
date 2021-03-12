using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringType;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringType
{
    class AddStringTypeHandler : IRequestHandler<AddStringTypeRequest, AddStringTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddStringTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddStringTypeResponse> Handle(AddStringTypeRequest request, CancellationToken cancellationToken)
        {
            var stringType = this.mapper.Map<DataAccess.Entities.StringType>(request);
            var command = new AddStringTypeCommand()
            {
                Parameter = stringType
            };
            var stringTypeFromDb = await this.commandExecutor.Execute(command);
            return new AddStringTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringType>(stringTypeFromDb)
            };
        }
    }
}
