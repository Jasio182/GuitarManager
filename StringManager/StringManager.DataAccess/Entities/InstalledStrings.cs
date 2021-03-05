using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class InstalledStrings : EntityBase
    {
        [Required]
        public int StringPosition { get; set; }
    }
}
