using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Player;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.Player;
using GuitarManager.DataAccess.CQRS.Queries.Player;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Player
{
    public class RemovePlayerHandler : IRequestHandler<RemovePlayerRequest, RemovePlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemovePlayerHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemovePlayerResponse> Handle(RemovePlayerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                Id = request.PlayerId
            };
            var player = await this.queryExecutor.Execute(query);
            if (player == null)
                return new RemovePlayerResponse()
                {
                    Data = null
                };
            var command = new RemovePlayerCommand()
            {
                Parameter = player
            };
            var removedPlayer = await this.commandExecutor.Execute(command);
            return new RemovePlayerResponse()
            {
                Data = this.mapper.Map<Domain.Models.Player>(removedPlayer)
            };
        }
    }
}
