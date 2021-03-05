using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class Sound : EntityBase
    {
        [Required]
        public string Pitch { get; set; }

        [Required]
        public double Frequency { get; set; }

    }
}
