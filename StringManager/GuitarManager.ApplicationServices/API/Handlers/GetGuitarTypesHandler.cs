using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetGuitarTypesHandler : IRequestHandler<GetGuitarTypesRequest, GetGuitarTypesResponse>
    {
        private readonly IRepository<GuitarType> guitarTypeRepository;

        public GetGuitarTypesHandler(IRepository<GuitarType> guitarTypeRepository)
        {
            this.guitarTypeRepository = guitarTypeRepository;
        }

        public Task<GetGuitarTypesResponse> Handle(GetGuitarTypesRequest request, CancellationToken cancellationToken)
        {
            var guitarTypes = this.guitarTypeRepository.GetAll();
            var domainGuitarTypes = guitarTypes.Select(x => new Domain.Models.GuitarType()
            {
                Id = x.Id,
                Type = x.Type,
                Instruments = x.Instruments,
                StringSets = x.StringSets
            });
            var response = new GetGuitarTypesResponse()
            {
                Data = domainGuitarTypes.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
