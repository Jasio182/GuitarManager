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
    public class GetStringTypesHandler : IRequestHandler<GetStringTypesRequest, GetStringTypesResponse>
    {
        private readonly IRepository<StringType> stringTypesRepository;
        private readonly IMapper mapper;

        public GetStringTypesHandler(IRepository<StringType> stringTypesRepository, IMapper mapper)
        {
            this.stringTypesRepository = stringTypesRepository;
            this.mapper = mapper;
        }

        public Task<GetStringTypesResponse> Handle(GetStringTypesRequest request, CancellationToken cancellationToken)
        {
            var stringTypes = this.stringTypesRepository.GetAll();
            var mappedStringTypes = this.mapper.Map<List<Domain.Models.StringType>>(stringTypes);
            var response = new GetStringTypesResponse()
            {
                Data = mappedStringTypes
            };
            return Task.FromResult(response);
        }
    }
}
