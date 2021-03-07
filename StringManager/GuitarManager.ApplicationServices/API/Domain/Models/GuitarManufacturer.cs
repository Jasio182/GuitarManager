using GuitarManager.DataAccess.Entities;
using System.Collections.Generic;

namespace GuitarManager.ApplicationServices.API.Domain.Models
{
    public class GuitarManufacturer
    {
        public int Id { get; set; }

        public string GuitarManufacturerName { get; set; }

        public List<Instrument> Instruments { get; set; }
    }
}
