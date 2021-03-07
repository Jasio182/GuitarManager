using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.ApplicationServices.API.Domain.Models
{
    public class MyInstrument
    {
        public int Id { get; set; }

        public int HoursWeekly { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastStringChange { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastDeepCleaning { get; set; }

        public int InstrumentID { get; set; }

        public int PlayerID { get; set; }
    }
}
