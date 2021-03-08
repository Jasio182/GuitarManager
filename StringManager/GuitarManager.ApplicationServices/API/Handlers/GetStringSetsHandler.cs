using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetStringSetsHandler : IRequestHandler<GetStringSetsRequest, GetStringSetsResponse>
    {
        private readonly IRepository<StringSet> stringSetsRepository;

        public GetStringSetsHandler(IRepository<StringSet> stringSetsRepository)
        {
            this.stringSetsRepository = stringSetsRepository;
        }

        public Task<GetStringSetsResponse> Handle(GetStringSetsRequest request, CancellationToken cancellationToken)
        {
            var stringSets = stringSetsRepository.GetAll();
            var domainStringSets = stringSets.Select(x => new Domain.Models.StringSet()
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfStrings = x.NumberOfStrings,
            });
            var response = new GetStringSetsResponse()
            {
                Data = domainStringSets.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
