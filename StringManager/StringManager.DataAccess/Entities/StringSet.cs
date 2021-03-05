using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    class StringSet : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int NumberOfStrings { get; set; }

    }
}
