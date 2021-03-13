using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.InstalledString;
using GuitarManager.DataAccess.CQRS.Queries.InstalledString;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.InstalledString
{
    class RemoveInstalledStringHandler : IRequestHandler<RemoveInstalledStringRequest, RemoveInstalledStringResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public RemoveInstalledStringHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<RemoveInstalledStringResponse> Handle(RemoveInstalledStringRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstalledStringByPositionAndMyInstrumentQuery()
            {
                MyInstrumentID = request.MyInstrumentID,
                StringPosition = request.StringPosition
            };
            var installedString = await this.queryExecutor.Execute(query);
            if (installedString == null)
                return new RemoveInstalledStringResponse()
                {
                    Data = null
                };
            var command = new RemoveInstalledStringCommand()
            {
                Parameter = installedString
            };
            var removedInstalledString = await this.commandExecutor.Execute(command);
            return new RemoveInstalledStringResponse()
            {
                Data = mapper.Map<Domain.Models.InstalledString>(removedInstalledString)
            };


        }
    }
}
