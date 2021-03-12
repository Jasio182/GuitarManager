using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;
using GuitarManager.ApplicationServices.API.Domain.StringType;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringTypesProfile : Profile
    {
        public StringTypesProfile()
        {
            this.CreateMap<AddStringTypeRequest, DataAccess.Entities.StringType > ()
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Type));

            this.CreateMap<DataAccess.Entities.StringType, StringType>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Type));
        }
    }
}
