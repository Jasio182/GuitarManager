using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.Player
{
    public class UpdatePlayerRequest : IRequest<UpdatePlayerResponse>
    {
        public int playerId;

        [Required]
        public string PlayStyle { get; set; }

        [Required]
        public string CareStyle { get; set; }
    }
}
