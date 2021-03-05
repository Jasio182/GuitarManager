using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class StringType : EntityBase
    {
        [Required]
        [MaxLength(300)]
        public string Type { get; set; }
    }
}
