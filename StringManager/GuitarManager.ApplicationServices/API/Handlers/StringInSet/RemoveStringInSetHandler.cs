using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringInSet;
using GuitarManager.DataAccess.CQRS.Queries.StringInSet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringInSet
{
    class RemoveStringInSetHandler : IRequestHandler<RemoveStringInSetRequest, RemoveStringInSetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public RemoveStringInSetHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<RemoveStringInSetResponse> Handle(RemoveStringInSetRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringInSetByStringSetAndPositionQuery()
            {
                StringPosition = request.StringPosition,
                StringSetID = request.StringSetID
            };
            var stringInSet = await this.queryExecutor.Execute(query);
            if (stringInSet == null)
                return new RemoveStringInSetResponse()
                {
                    Data = null
                };
            var command = new RemoveStringInSetCommand()
            {
                Parameter = stringInSet
            };
            var removedStringInSet = await this.commandExecutor.Execute(command);
            return new RemoveStringInSetResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringInSet>(removedStringInSet)
            };
        }
    }
}
