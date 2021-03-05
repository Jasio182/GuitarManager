using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class Player : EntityBase
    {
        [Required]
        public string PlayStyle { get; set; }

        [Required]
        public string CareStyle { get; set; }

        public Account AccountID { get; set; }

        public List<MyInstrument> MyInstruments { get; set; }
    }
}
