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
    }
}
