using GuitarManager.DataAccess.Entities;
using System.Collections.Generic;

namespace GuitarManager.ApplicationServices.API.Domain.Models
{
    public class GuitarType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public List<Instrument> Instruments { get; set; }

        public List<StringSet> StringSets { get; set; }
    }
}
