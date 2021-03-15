using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.InstalledString
{
    public class UpdateInstalledStringRequest : IRequest<UpdateInstalledStringResponse>
    {
        [Required]
        public int routeStringPosition;

        public int routeMyInstrumentID;

        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }

        public int StringID { get; set; }

        public int SoundID { get; set; }
    }
}
