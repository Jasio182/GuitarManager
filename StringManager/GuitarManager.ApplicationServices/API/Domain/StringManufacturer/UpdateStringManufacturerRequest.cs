using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.StringManufacturer
{
    public class UpdateStringManufacturerRequest : IRequest<UpdateStringManufacturerResponse>
    {
        public int stringManufacturerId;

        [Required]
        [MaxLength(150)]
        public string StringManufacturerName { get; set; }
    }
}
