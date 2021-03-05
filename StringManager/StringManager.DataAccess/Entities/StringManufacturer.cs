using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class StringManufacturer : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string StringManufacturerName { get; set; }
    }
}
