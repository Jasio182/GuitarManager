using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class StringInSet : EntityBase
    {
        [Required]
        public int StringPosition { get; set; }

        public int StringID { get; set; }

        public int StringSetID { get; set; }
    }
}
