using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Player;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.Player;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Player
{
    public class AddPlayerHandler : IRequestHandler<AddPlayerRequest, AddPlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddPlayerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddPlayerResponse> Handle(AddPlayerRequest request, CancellationToken cancellationToken)
        {
            var player = this.mapper.Map<DataAccess.Entities.Player>(request);
            var command = new AddPlayerCommand()
            {
                Parameter = player
            };
            var playerFromDb = await this.commandExecutor.Execute(command);
            return new AddPlayerResponse()
            {
                Data = this.mapper.Map<Domain.Models.Player>(playerFromDb)
            };
        }
    }
}
