using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;
using GuitarManager.ApplicationServices.API.Domain.String;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringsProfile :Profile
    {
        public StringsProfile() 
        {
            this.CreateMap<AddStringRequest, DataAccess.Entities.String>()
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.BulkDensity, y => y.MapFrom(z => z.BulkDensity))
            .ForMember(x => x.StringManufacturerID, y => y.MapFrom(z => z.StringManufacturerID))
            .ForMember(x => x.StringTypeID, y => y.MapFrom(z => z.StringTypeID));

            this.CreateMap<DataAccess.Entities.String, String>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.BulkDensity, y => y.MapFrom(z => z.BulkDensity))
            .ForMember(x => x.StringManufacturerID, y => y.MapFrom(z => z.StringManufacturerID))
            .ForMember(x => x.StringTypeID, y => y.MapFrom(z => z.StringTypeID));
        }
    }
}
