namespace GuitarManager.ApplicationServices.API.Domain.InstalledString
{
    interface IAddAndUpdateInstalledStringProperties
    {
        public int StringPosition { get; set; }

        public int MyInstrumentID { get; set; }

        public int StringID { get; set; }

        public int SoundID { get; set; }
    }
}
