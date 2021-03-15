using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.GuitarType
{
    public class UpdateGuitarTypeRequest : IRequest<UpdateGuitarTypeResponse>
    {
        public int guitarTypeId;

        [Required]
        [MaxLength(300)]
        public string Type { get; set; }
    }
}
