using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.String;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.String;
using GuitarManager.DataAccess.CQRS.Queries.String;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.String
{
    class UpdateStringHandler : IRequestHandler<UpdateStringRequest, UpdateStringResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateStringHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateStringResponse> Handle(UpdateStringRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringByIdQuery()
            {
                Id = request.stringId
            };
            var gotString = await this.queryExecutor.Execute(query);
            if (gotString == null)
                return new UpdateStringResponse()
                {
                    Data = null
                };
            var command = new UpdateStringCommand()
            {
                Parameter = this.mapper.Map(request, gotString)
            };
            var updatedString = await this.commandExecutor.Execute(command);
            return new UpdateStringResponse()
            {
                Data = this.mapper.Map<Domain.Models.String>(updatedString)
            };
        }
    }
}
