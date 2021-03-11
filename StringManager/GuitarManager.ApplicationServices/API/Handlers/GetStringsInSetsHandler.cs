using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    class GetStringsInSetsHandler : IRequestHandler<GetStringsInSetsRequest, GetStringsInSetsResponse>
    {
        private readonly IRepository<StringInSet> stringsInSetsRepository;
        private readonly IMapper mapper;

        public GetStringsInSetsHandler(IRepository<StringInSet> stringsInSetsRepository, IMapper mapper)
        {
            this.stringsInSetsRepository = stringsInSetsRepository;
            this.mapper = mapper;
        }
        public async Task<GetStringsInSetsResponse> Handle(GetStringsInSetsRequest request, CancellationToken cancellationToken)
        {
            var stringInSets = await this.stringsInSetsRepository.GetAll();
            var mappedStringsInSets = this.mapper.Map<List<Domain.Models.StringInSet>>(stringInSets);
            var response = new GetStringsInSetsResponse()
            {
                Data = mappedStringsInSets
            };
            return response;
        }
    }
}
