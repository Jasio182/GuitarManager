using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class InstalledStringsProfile : Profile
    {
        public InstalledStringsProfile()
        {
            this.CreateMap<AddInstalledStringRequest, DataAccess.Entities.InstalledString>()
             .ForMember(x => x.StringPosition, y => y.MapFrom(z => z.StringPosition))
             .ForMember(x => x.StringID, y => y.MapFrom(z => z.StringID))
             .ForMember(x => x.SoundID, y => y.MapFrom(z => z.SoundID))
             .ForMember(x => x.MyInstrumentID, y => y.MapFrom(z => z.MyInstrumentID));

            this.CreateMap<DataAccess.Entities.InstalledString, InstalledString>()
             .ForMember(x => x.StringPosition, y => y.MapFrom(z => z.StringPosition))
             .ForMember(x => x.StringID, y => y.MapFrom(z => z.StringID))
             .ForMember(x => x.SoundID, y => y.MapFrom(z => z.SoundID))
             .ForMember(x => x.MyInstrumentID, y => y.MapFrom(z => z.MyInstrumentID));
        }
    }
}
