using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Models;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;

namespace GuitarManager.ApplicationServices.Profiles
{
    class StringsInSetsProfile : Profile
    {
        public StringsInSetsProfile()
        {
            this.CreateMap<UpdateStringInSetRequest, DataAccess.Entities.StringInSet>()
                .ForMember(x => x.StringPosition, y => y.MapFrom(z => z.StringPosition))
                .ForMember(x => x.StringID, y => y.MapFrom(z => z.StringID))
                .ForMember(x => x.StringSetID, y => y.MapFrom(z => z.StringSetID));

            this.CreateMap<AddStringInSetRequest, DataAccess.Entities.StringInSet > ()
                .ForMember(x => x.StringPosition, y => y.MapFrom(z => z.StringPosition))
                .ForMember(x => x.StringID, y => y.MapFrom(z => z.StringID))
                .ForMember(x => x.StringSetID, y => y.MapFrom(z => z.StringSetID));

            this.CreateMap<DataAccess.Entities.StringInSet, StringInSet>()
                .ForMember(x => x.StringPosition, y => y.MapFrom(z => z.StringPosition))
                .ForMember(x => x.StringID, y => y.MapFrom(z => z.StringID))
                .ForMember(x => x.StringSetID, y => y.MapFrom(z => z.StringSetID));
        }
    }
}
