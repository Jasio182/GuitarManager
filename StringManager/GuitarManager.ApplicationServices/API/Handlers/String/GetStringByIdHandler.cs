using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.String;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.String;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.String
{
    public class GetStringByIdHandler : IRequestHandler<GetStringByIdRequest, GetStringByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetStringByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetStringByIdResponse> Handle(GetStringByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringByIdQuery()
            {
                Id = request.StringId
            };
            var thisString = await this.queryExecutor.Execute(query);
            var mappedString = this.mapper.Map<Domain.Models.String>(thisString);
            var response = new GetStringByIdResponse()
            {
                Data = mappedString
            };
            return response;
        }
    }
}
