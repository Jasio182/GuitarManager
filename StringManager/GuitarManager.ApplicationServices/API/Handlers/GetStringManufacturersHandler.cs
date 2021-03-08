using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetStringManufacturersHandler : IRequestHandler<GetStringManufacturersRequest, GetStringManufacturersResponse>
    {
        private readonly IRepository<StringManufacturer> stringManufacturerRepository;

        public GetStringManufacturersHandler(IRepository<StringManufacturer> stringManufacturerRepository)
        {
            this.stringManufacturerRepository = stringManufacturerRepository;
        }

        public Task<GetStringManufacturersResponse> Handle(GetStringManufacturersRequest request, CancellationToken cancellationToken)
        {
            var stringManufacturers = stringManufacturerRepository.GetAll();
            var domainStringManufacturers = stringManufacturers.Select(x => new Domain.Models.StringManufacturer()
            {
                Id = x.Id,
                StringManufacturerName = x.StringManufacturerName
            });
            var response = new GetStringManufacturersResponse()
            {
                Data = domainStringManufacturers.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
