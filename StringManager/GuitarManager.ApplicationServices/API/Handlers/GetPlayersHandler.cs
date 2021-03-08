using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetPlayersHandler : IRequestHandler<GetPlayersRequest, GetPlayersResponse>
    {
        private readonly IRepository<Player> playerRepository;
        private readonly IMapper mapper;

        public GetPlayersHandler(IRepository<Player> playerRepository, IMapper mapper)
        {
            this.playerRepository = playerRepository;
            this.mapper = mapper;
        }

        public Task<GetPlayersResponse> Handle(GetPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = playerRepository.GetAll();
            var mappedPlayers = this.mapper.Map<List<Domain.Models.Player>>(players);
            var response = new GetPlayersResponse()
            {
                Data = mappedPlayers.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
