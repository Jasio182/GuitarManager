using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.Sound
{
    public class GetSoundByIdRequest : IRequest<GetSoundByIdResponse>
    {
        public int SoundId { get; set; }
    }
}
