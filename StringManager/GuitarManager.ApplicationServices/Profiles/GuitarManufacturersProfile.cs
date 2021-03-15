using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    public class GuitarManufacturersProfile : Profile
    {
        public GuitarManufacturersProfile()
        {
            this.CreateMap<UpdateGuitarManufacturerRequest, DataAccess.Entities.GuitarManufacturer>()
            .ForMember(x => x.Id, y => y.MapFrom(z=>z.guitarManufacturerId))
            .ForMember(x => x.GuitarManufacturerName, y => y.MapFrom(z => z.GuitarManufacturerName));

            this.CreateMap<AddGuitarManufacturerRequest, DataAccess.Entities.GuitarManufacturer>()
            .ForMember(x => x.GuitarManufacturerName, y => y.MapFrom(z => z.GuitarManufacturerName));

            this.CreateMap<DataAccess.Entities.GuitarManufacturer, GuitarManufacturer>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.GuitarManufacturerName, y => y.MapFrom(z => z.GuitarManufacturerName));
        }
    }
}
