using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.MyInstrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.MyInstrument;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.MyInstrument
{
    public class GetMyInstrumentByIdHandler : IRequestHandler<GetMyInstrumentByIdRequest, GetMyInstrumentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetMyInstrumentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetMyInstrumentByIdResponse> Handle(GetMyInstrumentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMyInstrumentByIdQuery()
            {
                Id = request.MyInstrumentId
            };
            var myInstrument = await this.queryExecutor.Execute(query);
            var mappedMyInstrument = this.mapper.Map<Domain.Models.MyInstrument>(myInstrument);
            var response = new GetMyInstrumentByIdResponse()
            {
                Data = mappedMyInstrument
            };
            return response;
        }
    }
}
