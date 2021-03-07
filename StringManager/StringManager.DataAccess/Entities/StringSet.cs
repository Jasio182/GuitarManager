using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class StringSet : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int NumberOfStrings { get; set; }

        public List<StringInSet> StringsInSets { get; set; }

        public int GuitarTypeID { get; set; }

    }
}
