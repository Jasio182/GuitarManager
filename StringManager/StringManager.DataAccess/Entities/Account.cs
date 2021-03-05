using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.DataAccess.Entities
{
    class Account : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string GuitarManufacturerName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [ForeignKey("Account")]
        public Player PlayerID { get; set; }
    }
}
