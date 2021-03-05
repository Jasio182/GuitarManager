using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class GuitarType : EntityBase
    {
        [Required]
        [MaxLength(300)]
        public string Type { get; set; }
    }
}
