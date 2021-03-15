using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer
{
    public class UpdateGuitarManufacturerRequest : IRequest<UpdateGuitarManufacturerResponse>
    {
        public int guitarManufacturerId;

        [Required]
        [MaxLength(150)]
        public string GuitarManufacturerName { get; set; }
    }
}
