using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class InstalledString : EntityBase
    {
        [Index("IX_PositionOnInstrument", 1, IsUnique = true)]
        [Required]
        public int StringPosition { get; set; }

        [Index("IX_PositionOnInstrument", 2, IsUnique = true)]
        public int MyInstrumentID { get; set; }

        public int StringID { get; set; }

        public int SoundID { get; set; }
    }
}
