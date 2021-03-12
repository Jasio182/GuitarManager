using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Player;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.Player;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.Player
{
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdRequest, GetPlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlayerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetPlayerByIdResponse> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                Id = request.PlayerId
            };
            var player = await this.queryExecutor.Execute(query);
            var mappedPlayer = this.mapper.Map<Domain.Models.Player>(player);
            var response = new GetPlayerByIdResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
