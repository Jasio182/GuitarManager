using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Sound;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.Sound;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetSoundByIdHandler : IRequestHandler<GetSoundByIdRequest, GetSoundByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetSoundByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetSoundByIdResponse> Handle(GetSoundByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSoundByIdQuery()
            {
                Id = request.SoundId
            };
            var sound = await this.queryExecutor.Execute(query);
            var mappedSound = this.mapper.Map<Domain.Models.Sound>(sound);
            var response = new GetSoundByIdResponse()
            {
                Data = mappedSound
            };
            return response;
        }
    }
}
