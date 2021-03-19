using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer
{
    public class AddGuitarManufacturerRequest : IRequest<AddGuitarManufacturerResponse>
    {
        public string GuitarManufacturerName { get; set; }
    }
}
