using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.Sound
{
    public class GetSoundRequest : IRequest<GetSoundResponse>
    {
        //public int soundId;
        public int soundId { get; set; }
    }
}
