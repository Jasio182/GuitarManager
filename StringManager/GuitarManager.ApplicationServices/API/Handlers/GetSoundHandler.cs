using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Sound;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    class GetSoundHandler : IRequestHandler<GetSoundRequest, GetSoundResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetSoundHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetSoundResponse> Handle(GetSoundRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSoundQuery()
            {
                Id = request.soundId
            };
            var sound = await this.queryExecutor.Execute(query);
            var mappedSounds = this.mapper.Map<Domain.Models.Sound>(sound);
            var response = new GetSoundResponse()
            {
                Data = mappedSounds
            };
            return response;
        }
    }
}
