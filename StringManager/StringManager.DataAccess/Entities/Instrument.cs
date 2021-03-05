using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManager.DataAccess.Entities
{
    class Instrument
    {
        public int id { get; set; }
        public string model { get; set; }
        public int numberOfStrings { get; set; }
        public int scaleLenghtBass { get; set; }
        public int scaleLenghtTreble { get; set; }

    }
}
