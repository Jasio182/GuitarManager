using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.DataAccess.Entities
{
    public class Player : EntityBase
    {
        [Required]
        public string PlayStyle { get; set; }

        [Required]
        public string CareStyle { get; set; }

        [ForeignKey("Account")]
        public Account AccountID { get; set; }

        public List<MyInstrument> MyInstruments { get; set; }
    }
}
