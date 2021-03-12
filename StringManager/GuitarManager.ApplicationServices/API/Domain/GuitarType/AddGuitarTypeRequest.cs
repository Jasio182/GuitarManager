using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.GuitarType
{
    public class AddGuitarTypeRequest : IRequest<AddGuitarTypeResponse>
    {
        [Required]
        [MaxLength(300)]
        public string Type { get; set; }
    }
}
