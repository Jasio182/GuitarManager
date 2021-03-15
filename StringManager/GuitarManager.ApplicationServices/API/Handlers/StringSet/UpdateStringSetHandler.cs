using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringSet;
using GuitarManager.DataAccess.CQRS.Queries.StringSet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringSet
{
    public class UpdateStringSetHandler : IRequestHandler<UpdateStringSetRequest, UpdateStringSetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateStringSetHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateStringSetResponse> Handle(UpdateStringSetRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringSetByIdQuery()
            {
                Id = request.stringSetId
            };
            var gotStringSet = await this.queryExecutor.Execute(query);
            if (gotStringSet == null)
                return new UpdateStringSetResponse()
                {
                    Data = null
                };
            var command = new UpdateStringSetCommand()
            {
                Parameter = this.mapper.Map(request, gotStringSet)
            };
            var stringSet = await this.commandExecutor.Execute(command);
            return new UpdateStringSetResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringSet>(stringSet)
            };
        }
    }
}
