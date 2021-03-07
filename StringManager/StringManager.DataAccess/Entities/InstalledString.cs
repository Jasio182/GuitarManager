using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class InstalledString : EntityBase
    {
        [Required]
        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }

        public int StringID { get; set; }

        public int SoundID { get; set; }
    }
}
