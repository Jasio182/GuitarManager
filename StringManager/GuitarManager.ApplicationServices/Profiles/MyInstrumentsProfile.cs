using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class MyInstrumentsProfile : Profile
    {
        public MyInstrumentsProfile() => this.CreateMap<DataAccess.Entities.MyInstrument, MyInstrument>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.HoursWeekly, y => y.MapFrom(z => z.HoursWeekly))
            .ForMember(x => x.LastStringChange, y => y.MapFrom(z => z.LastStringChange))
            .ForMember(x => x.LastDeepCleaning, y => y.MapFrom(z => z.LastDeepCleaning))
            .ForMember(x => x.InstrumentID, y => y.MapFrom(z => z.InstrumentID))
            .ForMember(x => x.PlayerID, y => y.MapFrom(z => z.PlayerID));
    }
}
