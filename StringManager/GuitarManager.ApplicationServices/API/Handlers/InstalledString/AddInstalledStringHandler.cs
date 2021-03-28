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
    public class AddInstalledStringHandler : IRequestHandler<AddInstalledStringRequest, AddInstalledStringResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddInstalledStringHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddInstalledStringResponse> Handle(AddInstalledStringRequest request, CancellationToken cancellationToken)
        {
            if (!await CheckInstalledString.CheckIfCorrect(request, queryExecutor))
                return new AddInstalledStringResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Conflict)
                };

            var installedString = this.mapper.Map<DataAccess.Entities.InstalledString>(request);
            var command = new AddInstalledStringCommand()
            {
                Parameter = installedString
            };
            var installedStringFromDb = await this.commandExecutor.Execute(command);
            return new AddInstalledStringResponse()
            {
                Data = mapper.Map<Domain.Models.InstalledString>(installedStringFromDb)
            };
        }
    }
}
