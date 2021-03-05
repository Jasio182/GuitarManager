using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class Instrument : EntityBase
    {
        [Required]
        [MaxLength(300)]
        public string Model { get; set; }

        [Required]
        public int NumberOfStrings { get; set; }

        [Required]
        public int ScaleLenghtBass { get; set; }

        [Required]
        public int ScaleLenghtTreble { get; set; }

        public List<MyInstrument> MyInstruments { get; set }

        public int GuitarTypeID { get; set; }

        public int GuitarManufacturerID { get; set; }
    }
}
