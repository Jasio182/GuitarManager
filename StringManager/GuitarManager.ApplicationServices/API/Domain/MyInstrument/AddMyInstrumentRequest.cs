using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.ApplicationServices.API.Domain.MyInstrument
{
    public class AddMyInstrumentRequest : IRequest<AddMyInstrumentResponse>
    {
        public int HoursWeekly { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastStringChange { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastDeepCleaning { get; set; }

        public int InstrumentID { get; set; }

        public int PlayerID { get; set; }
    }
}
