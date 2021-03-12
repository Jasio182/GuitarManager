using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.StringManufacturer
{
    public class AddStringManufacturerRequest : IRequest<AddStringManufacturerResponse>
    {
        [Required]
        [MaxLength(150)]
        public string StringManufacturerName { get; set; }
    }
}
