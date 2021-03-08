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
    public class GetSoundsHandler : IRequestHandler<GetSoundsRequest, GetSoundsResponse>
    {
        private readonly IRepository<Sound> soundRepository;
        private readonly IMapper mapper;

        public GetSoundsHandler(IRepository<Sound> soundRepository, IMapper mapper)
        {
            this.soundRepository = soundRepository;
            this.mapper = mapper;
        }

        public Task<GetSoundsResponse> Handle(GetSoundsRequest request, CancellationToken cancellationToken)
        {
            var sounds = this.soundRepository.GetAll();
            var mappedSounds = this.mapper.Map<List<Domain.Models.Sound>>(sounds);
            var response = new GetSoundsResponse()
            {
                Data = mappedSounds
            };
            return Task.FromResult(response);
        }
    }
}
