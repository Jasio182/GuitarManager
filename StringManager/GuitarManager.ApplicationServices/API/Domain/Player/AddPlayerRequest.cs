using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.ApplicationServices.API.Domain.Player
{
    public class AddPlayerRequest:IRequest<AddPlayerResponse>
    {
        [Required]
        public string PlayStyle { get; set; }

        [Required]
        public string CareStyle { get; set; }
    }
}
