using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.StringInSet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringInSet
{
    public class GetStringInSetByStringSetAndPositionHandler : IRequestHandler<GetStringInSetByStringSetAndPositionRequest, GetStringInSetByStringSetAndPositionResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetStringInSetByStringSetAndPositionHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetStringInSetByStringSetAndPositionResponse> Handle(GetStringInSetByStringSetAndPositionRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringInSetByStringSetAndPositionQuery()
            {
                StringPosition = request.StringPosition,
                StringSetID = request.StringSetID
            };
            var stringInSet = await this.queryExecutor.Execute(query);
            var mappedStringInSet = mapper.Map<Domain.Models.StringInSet>(stringInSet);
            var response = new GetStringInSetByStringSetAndPositionResponse()
            {
                Data = mappedStringInSet
            };
            return response;
        }
    }
}
