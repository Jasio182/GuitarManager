using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;
using GuitarManager.ApplicationServices.API.Domain.StringSet;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringSetsProfile : Profile
    {
        public StringSetsProfile()
        {
            this.CreateMap<UpdateStringSetRequest, DataAccess.Entities.StringSet>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.stringSetId))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.NumberOfStrings, y => y.MapFrom(z => z.NumberOfStrings))
           .ForMember(x => x.GuitarTypeID, y => y.MapFrom(z => z.GuitarTypeID));

            this.CreateMap<AddStringSetRequest, DataAccess.Entities.StringSet>()
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.NumberOfStrings, y => y.MapFrom(z => z.NumberOfStrings))
           .ForMember(x => x.GuitarTypeID, y => y.MapFrom(z => z.GuitarTypeID));

            this.CreateMap<DataAccess.Entities.StringSet, StringSet>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.NumberOfStrings, y => y.MapFrom(z => z.NumberOfStrings));
        }
    }
}
