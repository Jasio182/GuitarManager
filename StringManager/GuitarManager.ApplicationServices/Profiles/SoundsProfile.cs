using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    public class SoundsProfile : Profile
    {
        public SoundsProfile() => this.CreateMap<DataAccess.Entities.Sound, Sound>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Frequency, y => y.MapFrom(z => z.Frequency))
            .ForMember(x => x.Pitch, y => y.MapFrom(z => z.Pitch));
    }
}
