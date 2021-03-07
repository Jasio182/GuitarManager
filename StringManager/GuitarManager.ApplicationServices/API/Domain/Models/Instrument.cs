namespace GuitarManager.ApplicationServices.API.Domain.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int NumberOfStrings { get; set; }

        public int ScaleLenghtBass { get; set; }

        public int ScaleLenghtTreble { get; set; }

        public int GuitarTypeID { get; set; }

        public int GuitarManufacturerID { get; set; }
    }
}
