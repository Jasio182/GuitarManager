using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer
{
    public class UpdateGuitarManufacturerRequest : IRequest<UpdateGuitarManufacturerResponse>
    {
        public int guitarManufacturerId;

        public string GuitarManufacturerName { get; set; }
    }
}
