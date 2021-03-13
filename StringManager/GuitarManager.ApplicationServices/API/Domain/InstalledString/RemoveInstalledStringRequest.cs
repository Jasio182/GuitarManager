using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.InstalledString
{
    public class RemoveInstalledStringRequest : IRequest<RemoveInstalledStringResponse>
    {
        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }
    }
}
