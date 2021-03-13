using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.MyInstrument
{
    public class RemoveMyInstrumentRequest : IRequest<RemoveMyInstrumentResponse>
    {
        public int MyInstrumentId { get; set; }
    }
}
