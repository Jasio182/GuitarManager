using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Sound;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries;

using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetSoundsHandler : IRequestHandler<GetSoundsRequest, GetSoundsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetSoundsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetSoundsResponse> Handle(GetSoundsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSoundsQuery();
            var sounds = await this.queryExecutor.Execute(query);
            var mappedSounds = this.mapper.Map<List<Domain.Models.Sound>>(sounds);
            var response = new GetSoundsResponse()
            {
                Data = mappedSounds
            };
            return response;
        }
    }
}
