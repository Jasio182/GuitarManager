using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.Instrument
{
    public class GetInstrumentsRequest : IRequest<GetInstrumentsResponse>
    {
        public int GuitarTypeID { get; set; }

        public int GuitarManufacturerID { get; set; }
    }
}
