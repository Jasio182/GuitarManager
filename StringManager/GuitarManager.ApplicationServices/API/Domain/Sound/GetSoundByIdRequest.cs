using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.Sound
{
    public class GetSoundByIdRequest : IRequest<GetSoundByIdResponse>
    {
        public int soundId { get; set; }
    }
}
