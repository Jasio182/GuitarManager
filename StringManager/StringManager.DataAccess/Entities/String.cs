using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class String : EntityBase
    {
        [Required]
        public double Size { get; set; }

        [Required]
        public double BulkDensity { get; set; }
    }
}
