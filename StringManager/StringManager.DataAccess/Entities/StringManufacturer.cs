using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class StringManufacturer : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string StringManufacturerName { get; set; }

        public List<String> Strings { get; set; }
    }
}
