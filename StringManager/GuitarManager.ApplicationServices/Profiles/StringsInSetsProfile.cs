using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringsInSetsProfile : Profile
    {
        public StringsInSetsProfile() => this.CreateMap<DataAccess.Entities.StringInSet, StringInSet>()
            .ForMember(x => x.StringPosition, y => y.MapFrom(z => z.StringPosition))
            .ForMember(x => x.StringID, y => y.MapFrom(z => z.StringID))
            .ForMember(x => x.StringSetID, y => y.MapFrom(z => z.StringSetID));
    }
}
