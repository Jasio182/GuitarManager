using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class GuitarType : EntityBase
    {
        [Required]
        [MaxLength(300)]
        public string Type { get; set; }

        public List<Instrument> Instruments { get; set; }

        public List<StringSet> StringSets { get; set; }
    }
}
