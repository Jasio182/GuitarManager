using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarManager.DataAccess.Entities
{
    public class Account : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [ForeignKey("Player")]
        public Player PlayerID { get; set; }
    }
}
