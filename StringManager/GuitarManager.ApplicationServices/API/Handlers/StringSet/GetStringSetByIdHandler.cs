using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.StringSet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringSet
{
    public class GetStringSetByIdHandler : IRequestHandler<GetStringSetByIdRequest, GetStringSetByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetStringSetByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetStringSetByIdResponse> Handle(GetStringSetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringSetByIdQuery()
            {
                Id = request.StringSetId
            };
            var stringSet = await this.queryExecutor.Execute(query);
            var mappedStringSet = this.mapper.Map<Domain.Models.StringSet>(stringSet);
            var response = new GetStringSetByIdResponse()
            {
                Data = mappedStringSet
            };
            return response;
        }
    }
}
