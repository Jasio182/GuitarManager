using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class Sound : EntityBase
    {
        [Required]
        public string Pitch { get; set; }

        [Required]
        public double Frequency { get; set; }

        public List<InstalledString> InstalledStrings { get; set; }

    }
}
