using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.Instrument
{
    public class GetInstrumentByIdRequest : IRequest<GetInstrumentByIdResponse>
    {
        public int InstrumentId { get; set; }
    }
}
