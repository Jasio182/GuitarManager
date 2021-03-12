
using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringManufacturersProfile:Profile
    {
        public StringManufacturersProfile()
        {
            this.CreateMap<AddStringManufacturerRequest ,DataAccess.Entities.StringManufacturer>()
            .ForMember(x => x.StringManufacturerName, y => y.MapFrom(z => z.StringManufacturerName));

            this.CreateMap<DataAccess.Entities.StringManufacturer, StringManufacturer>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.StringManufacturerName, y => y.MapFrom(z => z.StringManufacturerName));
        }


    }
}
