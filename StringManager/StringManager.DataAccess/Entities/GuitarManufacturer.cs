using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class GuitarManufacturer : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string GuitarManufacturerName { get; set; }

        public List<Instrument> Instruments { get; set; }
    }
}
