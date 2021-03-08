using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;

namespace GuitarManager.ApplicationServices.Profiles
{
    class PlayersProfile : Profile
    {
        public PlayersProfile() => this.CreateMap<DataAccess.Entities.Player, Player>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.PlayStyle, y => y.MapFrom(z => z.PlayStyle))
            .ForMember(x => x.CareStyle, y => y.MapFrom(z => z.CareStyle));
    }
}
