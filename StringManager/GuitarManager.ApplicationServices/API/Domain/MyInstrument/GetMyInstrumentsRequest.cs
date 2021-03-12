using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.MyInstrument
{
    public class GetMyInstrumentsRequest : IRequest<GetMyInstrumentsResponse>
    {
        public int PlayerID { get; set; }
    }
}
