using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetGuitarManufacturersHandler : IRequestHandler<GetGuitarManufacturersRequest, GetGuitarManufacturersResponse>
    {
        private readonly IRepository<GuitarManufacturer> guitarManufacturerRepository;

        public GetGuitarManufacturersHandler(IRepository<GuitarManufacturer> guitarManufacturerRepository)
        {
            this.guitarManufacturerRepository = guitarManufacturerRepository;
        }

        public Task<GetGuitarManufacturersResponse> Handle(GetGuitarManufacturersRequest request, CancellationToken cancellationToken)
        {
            var guitarManufacturers = this.guitarManufacturerRepository.GetAll();
            var domainguitarManufacturers = guitarManufacturers.Select(x => new Domain.Models.GuitarManufacturer()
            {
                Id = x.Id,
                GuitarManufacturerName = x.GuitarManufacturerName
            });
            var response = new GetGuitarManufacturersResponse()
            {
                Data = domainguitarManufacturers.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
