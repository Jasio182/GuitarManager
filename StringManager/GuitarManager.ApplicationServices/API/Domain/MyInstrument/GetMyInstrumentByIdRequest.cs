using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.MyInstrument
{
    public class GetMyInstrumentByIdRequest : IRequest<GetMyInstrumentByIdResponse>
    {
        public int MyInstrumentId { get; set; }
    }
}
