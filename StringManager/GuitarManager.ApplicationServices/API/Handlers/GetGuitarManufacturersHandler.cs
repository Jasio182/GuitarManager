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
    public class GetGuitarManufacturersHandler : IRequestHandler<GetGuitarManufacturersRequest, GetGuitarManufacturersResponse>
    {
        private readonly IRepository<GuitarManufacturer> guitarManufacturerRepository;
        private readonly IMapper mapper;

        public GetGuitarManufacturersHandler(IRepository<GuitarManufacturer> guitarManufacturerRepository, IMapper mapper)
        {
            this.guitarManufacturerRepository = guitarManufacturerRepository;
            this.mapper = mapper;
        }

        public async Task<GetGuitarManufacturersResponse> Handle(GetGuitarManufacturersRequest request, CancellationToken cancellationToken)
        {
            var guitarManufacturers = await this.guitarManufacturerRepository.GetAll();
            var mappedGuitarManufacturers = this.mapper.Map<List<Domain.Models.GuitarManufacturer>>(guitarManufacturers);
            var response = new GetGuitarManufacturersResponse()
            {
                Data = mappedGuitarManufacturers
            };
            return response;
        }
    }
}
