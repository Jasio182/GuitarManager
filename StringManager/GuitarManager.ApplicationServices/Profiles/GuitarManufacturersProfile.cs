using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    public class GuitarManufacturersProfile : Profile
    {
        public GuitarManufacturersProfile() => this.CreateMap<DataAccess.Entities.GuitarManufacturer, GuitarManufacturer>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.GuitarManufacturerName, y => y.MapFrom(z => z.GuitarManufacturerName));
    }
}
