using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetSoundsHandler : IRequestHandler<GetSoundsRequest, GetSoundsResponse>
    {
        private readonly IRepository<Sound> soundRepository;

        public GetSoundsHandler(IRepository<Sound> soundRepository)
        {
            this.soundRepository = soundRepository;
        }

        public Task<GetSoundsResponse> Handle(GetSoundsRequest request, CancellationToken cancellationToken)
        {
            var sounds = this.soundRepository.GetAll();
            var domainSounds = sounds.Select(x => new Domain.Models.Sound()
            {
                Id = x.Id,
                Pitch = x.Pitch,
                Frequency = x.Frequency
            });
            var response = new GetSoundsResponse()
            {
                Data = domainSounds.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
