using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class StringInSet : EntityBase
    {
        [Required]
        public int StringPosition { get; set; }
    }
}
