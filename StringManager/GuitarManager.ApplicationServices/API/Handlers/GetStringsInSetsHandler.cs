using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    class GetStringsInSetsHandler : IRequestHandler<GetStringsInSetsRequest, GetStringsInSetsResponse>
    {
        private readonly IRepository<StringInSet> stringsInSetsRepository;

        public GetStringsInSetsHandler(IRepository<StringInSet> stringsInSetsRepository)
        {
            this.stringsInSetsRepository = stringsInSetsRepository;
        }
        public Task<GetStringsInSetsResponse> Handle(GetStringsInSetsRequest request, CancellationToken cancellationToken)
        {
            var stringInSets = stringsInSetsRepository.GetAll();
            var domiainStringsInSets = stringInSets.Select(x => new Domain.Models.StringInSet()
            {
                StringPosition = x.StringPosition,
                StringID = x.StringID,
                StringSetID = x.StringSetID
            });
            var response = new GetStringsInSetsResponse()
            {
                Data = domiainStringsInSets.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
