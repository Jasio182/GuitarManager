using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public class String : EntityBase
    {
        [Required]
        public double Size { get; set; }

        [Required]
        public double BulkDensity { get; set; }

        public List<InstalledString> InstalledStrings { get; set; }

        public List<StringInSet> StringsInSets { get; set; }

        public int StringTypeID { get; set; }

        public int StringManufacturerID { get; set; }
    }
}
