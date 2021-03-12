using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringInSet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringInSet
{
    public class AddStringInSetHandler : IRequestHandler<AddStringInSetRequest, AddStringInSetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddStringInSetHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddStringInSetResponse> Handle(AddStringInSetRequest request, CancellationToken cancellationToken)
        {
            var stringInSet = this.mapper.Map<DataAccess.Entities.StringInSet>(request);
            var command = new AddStringInSetCommand()
            {
                Parameter = stringInSet
            };
            var stringInSetFromDb = await this.commandExecutor.Execute(command);
            return new AddStringInSetResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringInSet>(stringInSetFromDb)
            };
        }
    }
}
