using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.String;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.String;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.String
{
    public class AddStringHandler : IRequestHandler<AddStringRequest, AddStringResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddStringHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddStringResponse> Handle(AddStringRequest request, CancellationToken cancellationToken)
        {
            var thisString = this.mapper.Map<DataAccess.Entities.String>(request);
            var command = new AddStringCommand()
            {
                Parameter = thisString
            };
            var stringFromDb = await this.commandExecutor.Execute(command);
            return new AddStringResponse()
            {
                Data = this.mapper.Map<Domain.Models.String>(stringFromDb)
            };
        }
    }
}
