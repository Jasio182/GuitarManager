using AutoMapper;
using GuitarManager.DataAccess.Entities;

namespace GuitarManager.ApplicationServices.Profiles
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile() => this.CreateMap<Account, API.Domain.Models.Account>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
            .ForMember(x => x.IsAdmin, y => y.MapFrom(z => z.IsAdmin));

    }
}
