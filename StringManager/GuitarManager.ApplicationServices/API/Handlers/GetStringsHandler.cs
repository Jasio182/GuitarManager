using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetStringsHandler : IRequestHandler<GetStringsRequest, GetStringsResponse>
    {
        private readonly IRepository<String> stringsRepository;

        public GetStringsHandler(IRepository<String> stringsRepository)
        {
            this.stringsRepository = stringsRepository;
        }

        public Task<GetStringsResponse> Handle(GetStringsRequest request, CancellationToken cancellationToken)
        {
            var strings = stringsRepository.GetAll();
            var domainStrings = strings.Select(x => new Domain.Models.String()
            {
                Id = x.Id,
                Size = x.Size,
                BulkDensity = x.BulkDensity,
                StringTypeID = x.StringTypeID,
                StringManufacturerID = x.StringManufacturerID
            });
            var response = new GetStringsResponse()
            {
                Data = domainStrings.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
