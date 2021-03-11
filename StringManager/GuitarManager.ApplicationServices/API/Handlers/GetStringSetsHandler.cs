using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringSet;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetStringSetsHandler : IRequestHandler<GetStringSetsRequest, GetStringSetsResponse>
    {
        private readonly IRepository<StringSet> stringSetsRepository;
        private readonly IMapper mapper;

        public GetStringSetsHandler(IRepository<StringSet> stringSetsRepository, IMapper mapper)
        {
            this.stringSetsRepository = stringSetsRepository;
            this.mapper = mapper;
        }

        public async Task<GetStringSetsResponse> Handle(GetStringSetsRequest request, CancellationToken cancellationToken)
        {
            var stringSets = await this.stringSetsRepository.GetAll();
            var mappedStringSets = this.mapper.Map<List<Domain.Models.StringSet>>(stringSets);
            var response = new GetStringSetsResponse()
            {
                Data = mappedStringSets
            };
            return response;
        }
    }
}
