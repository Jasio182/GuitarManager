using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.InstalledString
{ 
    public class GetInstalledStringByPositionAndMyInstrumentRequest : IRequest<GetInstalledStringByPositionAndMyInstrumentResponse>
    {
        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }
    }
}
