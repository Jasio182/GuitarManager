using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Player;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.Player;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Player
{
    public class GetPlayersHandler : IRequestHandler<GetPlayersRequest, GetPlayersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetPlayersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetPlayersResponse> Handle(GetPlayersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayersQuery();
            var players = await this.queryExecutor.Execute(query);
            var mappedPlayers = mapper.Map<List<Domain.Models.Player>>(players);
            var response = new GetPlayersResponse()
            {
                Data = mappedPlayers.ToList()
            };
            return response;
        }
    }
}
