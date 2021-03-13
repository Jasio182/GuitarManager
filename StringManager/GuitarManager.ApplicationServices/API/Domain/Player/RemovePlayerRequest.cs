using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.Player
{
    public class RemovePlayerRequest : IRequest<RemovePlayerResponse>
    {
        public int PlayerId { get; set; }

    }
}
