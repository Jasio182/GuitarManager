using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer
{
    public class AddGuitarManufacturerRequest : IRequest<AddGuitarManufacturerResponse>
    {
        //[Required]
        //[MaxLength(150)]
        public string GuitarManufacturerName { get; set; }
    }
}
