using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.DataAccess.Entities
{
    class MyInstrument : EntityBase
    {
        [Required]
        public int HoursWeekly { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastStringChange { get; set; }

        [Column(TypeName = "Date")]
        public DateTime LastDeepCleaning { get; set; }

        public int InstrumentID { get; set; }

        public int PlayerID { get; set; }

        public List<InstalledString> InstalledStrings { get; set; }
    }
}
