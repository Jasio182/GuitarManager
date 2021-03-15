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
    public class UpdateStringInSetHandler : IRequestHandler<UpdateStringInSetRequest, UpdateStringInSetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateStringInSetHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateStringInSetResponse> Handle(UpdateStringInSetRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringInSetByStringSetAndPositionQuery()
            {
                StringPosition = request.routeStringPosition,
                StringSetID = request.routeStringSetID
            };
            var gotStringInSet = await this.queryExecutor.Execute(query);
            if (gotStringInSet == null)
                return new UpdateStringInSetResponse()
                {
                    Data = null
                };
            var command = new UpdateStringInSetCommand()
            {
                Parameter = this.mapper.Map(request, gotStringInSet)
            };
            var stringInSet = await this.commandExecutor.Execute(command);
            return new UpdateStringInSetResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringInSet>(stringInSet)
            };
        }
    }
}
