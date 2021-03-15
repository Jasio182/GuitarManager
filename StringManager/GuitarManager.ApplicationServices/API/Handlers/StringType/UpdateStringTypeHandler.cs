using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringType;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringType;
using GuitarManager.DataAccess.CQRS.Queries.StringType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringType
{
    class UpdateStringTypeHandler : IRequestHandler<UpdateStringTypeRequest, UpdateStringTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateStringTypeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateStringTypeResponse> Handle(UpdateStringTypeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringTypeByIdQuery()
            {
                Id = request.stringTypeId
            };
            var gotStringType = await this.queryExecutor.Execute(query);
            if (gotStringType == null)
                return new UpdateStringTypeResponse()
                {
                    Data = null
                };
            var command = new UpdateStringTypeCommand()
            {
                Parameter = this.mapper.Map(request, gotStringType)
            };
            var stringType = await this.commandExecutor.Execute(command);
            return new UpdateStringTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringType>(stringType)
            };
        }
    }
}
