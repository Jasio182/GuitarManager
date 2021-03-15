using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.Instrument
{
    public class UpdateInstrumentRequest : IRequest<UpdateInstrumentResponse>
    {
        public int instrumentId;
        [Required]
        [MaxLength(300)]
        public string Model { get; set; }

        [Required]
        public int NumberOfStrings { get; set; }

        [Required]
        public int ScaleLenghtBass { get; set; }

        [Required]
        public int ScaleLenghtTreble { get; set; }

        public int GuitarTypeID { get; set; }

        public int GuitarManufacturerID { get; set; }
    }
}
