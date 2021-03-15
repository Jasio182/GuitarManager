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
    public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerRequest, UpdatePlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdatePlayerHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdatePlayerResponse> Handle(UpdatePlayerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                Id = request.playerId
            };
            var gotPlayer = await this.queryExecutor.Execute(query);
            if (gotPlayer == null)
                return new UpdatePlayerResponse()
                {
                    Data = null
                };
            var command = new UpdatePlayerCommand()
            {
                Parameter = this.mapper.Map(request, gotPlayer)
            };
            var player = await this.commandExecutor.Execute(command);
            return new UpdatePlayerResponse()
            {
                Data = this.mapper.Map<Domain.Models.Player>(player)
            };
        }
    }
}
