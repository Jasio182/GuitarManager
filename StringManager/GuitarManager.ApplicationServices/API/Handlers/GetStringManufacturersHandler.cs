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
    public class GetStringManufacturersHandler : IRequestHandler<GetStringManufacturersRequest, GetStringManufacturersResponse>
    {
        private readonly IRepository<StringManufacturer> stringManufacturerRepository;
        private readonly IMapper mapper;

        public GetStringManufacturersHandler(IRepository<StringManufacturer> stringManufacturerRepository, IMapper mapper)
        {
            this.stringManufacturerRepository = stringManufacturerRepository;
            this.mapper = mapper;
        }

        public Task<GetStringManufacturersResponse> Handle(GetStringManufacturersRequest request, CancellationToken cancellationToken)
        {
            var stringManufacturers = stringManufacturerRepository.GetAll();
            var mappedStringManufacturers = mapper.Map<List<Domain.Models.StringManufacturer>>(stringManufacturers);
            var response = new GetStringManufacturersResponse()
            {
                Data = mappedStringManufacturers
            };
            return Task.FromResult(response);
        }
    }
}
