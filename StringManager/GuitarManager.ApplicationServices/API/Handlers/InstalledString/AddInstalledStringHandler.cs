using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.InstalledString;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.InstalledString
{
    public class AddInstalledStringHandler : IRequestHandler<AddInstalledStringRequest, AddInstalledStringResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddInstalledStringHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddInstalledStringResponse> Handle(AddInstalledStringRequest request, CancellationToken cancellationToken)
        {
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
