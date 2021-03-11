using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.String;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetStringsHandler : IRequestHandler<GetStringsRequest, GetStringsResponse>
    {
        private readonly IRepository<String> stringsRepository;
        private readonly IMapper mapper;

        public GetStringsHandler(IRepository<String> stringsRepository, IMapper mapper)
        {
            this.stringsRepository = stringsRepository;
            this.mapper = mapper;
        }

        public async Task<GetStringsResponse> Handle(GetStringsRequest request, CancellationToken cancellationToken)
        {
            var strings = await this.stringsRepository.GetAll();
            var mappedString = this.mapper.Map<List<Domain.Models.String>>(strings);
            var response = new GetStringsResponse()
            {
                Data = mappedString
            };
            return response;
        }
    }
}
