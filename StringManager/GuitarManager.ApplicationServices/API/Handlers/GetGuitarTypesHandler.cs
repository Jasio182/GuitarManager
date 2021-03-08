using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetGuitarTypesHandler : IRequestHandler<GetGuitarTypesRequest, GetGuitarTypesResponse>
    {
        private readonly IRepository<GuitarType> guitarTypeRepository;
        private readonly IMapper mapper;

        public GetGuitarTypesHandler(IRepository<GuitarType> guitarTypeRepository, IMapper mapper)
        {
            this.guitarTypeRepository = guitarTypeRepository;
            this.mapper = mapper;
        }

        public Task<GetGuitarTypesResponse> Handle(GetGuitarTypesRequest request, CancellationToken cancellationToken)
        {
            var guitarTypes = this.guitarTypeRepository.GetAll();
            var domainGuitarTypes = this.mapper.Map<List<Domain.Models.GuitarType>>(guitarTypes);
            var response = new GetGuitarTypesResponse()
            {
                Data = domainGuitarTypes
            };
            return Task.FromResult(response);
        }
    }
}
