using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class InstalledString : EntityBase
    {
        [Required]
        public int StringPosition { get; set; }
    }
}
