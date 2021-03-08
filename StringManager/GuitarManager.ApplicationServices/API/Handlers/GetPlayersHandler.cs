using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetPlayersHandler : IRequestHandler<GetPlayersRequest, GetPlayersResponse>
    {
        private readonly IRepository<Player> playerRepository;

        public GetPlayersHandler(IRepository<Player> playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public Task<GetPlayersResponse> Handle(GetPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = playerRepository.GetAll();
            var domainPlayers = players.Select(x => new Domain.Models.Player()
            {
                Id = x.Id,
                PlayStyle = x.PlayStyle,
                CareStyle = x.CareStyle
            });
            var response = new GetPlayersResponse()
            {
                Data = domainPlayers.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
