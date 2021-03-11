using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;
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

        public async Task<GetStringManufacturersResponse> Handle(GetStringManufacturersRequest request, CancellationToken cancellationToken)
        {
            var stringManufacturers = await this.stringManufacturerRepository.GetAll();
            var mappedStringManufacturers = this.mapper.Map<List<Domain.Models.StringManufacturer>>(stringManufacturers);
            var response = new GetStringManufacturersResponse()
            {
                Data = mappedStringManufacturers
            };
            return response;
        }
    }
}
