using System.Collections.Generic;

namespace GuitarManager.ApplicationServices.API.Domain.Models
{
    public class String
    {
        public int Id { get; set; }

        public double Size { get; set; }

        public double BulkDensity { get; set; }

        public int StringTypeID { get; set; }

        public int StringManufacturerID { get; set; }
    }
}
