using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.ErrorHandling;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.InstalledString;
using GuitarManager.DataAccess.CQRS.Queries.InstalledString;
using GuitarManager.DataAccess.CQRS.Queries.MyInstrument;
using GuitarManager.DataAccess.CQRS.Queries.Sound;
using GuitarManager.DataAccess.CQRS.Queries.String;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.InstalledString
{
    public class UpdateInstalledStringHandler : IRequestHandler<UpdateInstalledStringRequest, UpdateInstalledStringResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateInstalledStringHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateInstalledStringResponse> Handle(UpdateInstalledStringRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstalledStringByPositionAndMyInstrumentQuery()
            {
                MyInstrumentID = request.routeMyInstrumentID,
                StringPosition = request.routeStringPosition
            };
            var gotInstalledString = await this.queryExecutor.Execute(query);
            if (!await CheckInstalledString.CheckIfCorrect(request, queryExecutor) && gotInstalledString != null)
                return new UpdateInstalledStringResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Conflict)
                };
            var command = new UpdateInstalledStringCommand()
            {
                Parameter = mapper.Map(request, gotInstalledString)
            };
            var installedString = await this.commandExecutor.Execute(command);
            return new UpdateInstalledStringResponse()
            {
                Data = mapper.Map<Domain.Models.InstalledString>(installedString)
            };
        }
    }
}
