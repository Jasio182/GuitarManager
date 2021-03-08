using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class GuitarTypesProfile : Profile
    {
        public GuitarTypesProfile() => this.CreateMap<DataAccess.Entities.GuitarType, GuitarType>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Type));
    }
}
