using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetStringTypesHandler : IRequestHandler<GetStringTypesRequest, GetStringTypesResponse>
    {
        private readonly IRepository<StringType> stringTypesRepository;

        public GetStringTypesHandler(IRepository<StringType> stringTypesRepository)
        {
            this.stringTypesRepository = stringTypesRepository;
        }

        public Task<GetStringTypesResponse> Handle(GetStringTypesRequest request, CancellationToken cancellationToken)
        {
            var stringTypes = stringTypesRepository.GetAll();
            var domainStringTypes = stringTypes.Select(x => new Domain.Models.StringType()
            {
                Id = x.Id,
                Type = x.Type
            });
            var response = new GetStringTypesResponse()
            {
                Data = domainStringTypes.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
