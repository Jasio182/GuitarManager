using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringSetsProfile : Profile
    {
        public StringSetsProfile() => this.CreateMap<DataAccess.Entities.StringSet, StringSet>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.NumberOfStrings, y => y.MapFrom(z => z.NumberOfStrings));
    }
}
