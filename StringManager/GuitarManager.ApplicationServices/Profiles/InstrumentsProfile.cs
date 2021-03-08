using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class InstrumentsProfile : Profile
    {
        public InstrumentsProfile() => this.CreateMap<DataAccess.Entities.Instrument, Instrument>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Model, y => y.MapFrom(z => z.Model))
            .ForMember(x => x.NumberOfStrings, y => y.MapFrom(z => z.NumberOfStrings))
            .ForMember(x => x.ScaleLenghtBass, y => y.MapFrom(z => z.ScaleLenghtBass))
            .ForMember(x => x.ScaleLenghtTreble, y => y.MapFrom(z => z.ScaleLenghtTreble))
            .ForMember(x => x.GuitarManufacturerID, y => y.MapFrom(z => z.GuitarManufacturerID))
            .ForMember(x => x.GuitarTypeID, y => y.MapFrom(z => z.GuitarTypeID));
    }
}
