using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.InstalledString;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.InstalledString
{
    class GetInstalledStringByPositionAndMyInstrumentHandler : IRequestHandler<GetInstalledStringByPositionAndMyInstrumentRequest, GetInstalledStringByPositionAndMyInstrumentResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetInstalledStringByPositionAndMyInstrumentHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetInstalledStringByPositionAndMyInstrumentResponse> Handle(GetInstalledStringByPositionAndMyInstrumentRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstalledStringByPositionAndMyInstrumentQuery()
            {
                MyInstrumentID = request.MyInstrumentID,
                StringPosition = request.StringPosition
            };
            var installedString = await this.queryExecutor.Execute(query);
            var mappedInstalledString = this.mapper.Map<Domain.Models.InstalledString>(installedString);
            var response = new GetInstalledStringByPositionAndMyInstrumentResponse()
            {
                Data = mappedInstalledString
            };
            return response;
        }
    }
}
