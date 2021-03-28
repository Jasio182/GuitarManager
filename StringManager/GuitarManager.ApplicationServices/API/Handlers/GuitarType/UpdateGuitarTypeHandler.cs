using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.ErrorHandling;
using GuitarManager.ApplicationServices.API.Domain.GuitarType;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.GuitarType;
using GuitarManager.DataAccess.CQRS.Queries.GuitarType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.GuitarType
{
    public class UpdateGuitarTypeHandler : IRequestHandler<UpdateGuitarTypeRequest, UpdateGuitarTypeResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateGuitarTypeHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateGuitarTypeResponse> Handle(UpdateGuitarTypeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGuitarTypeByIdQuery()
            {
                Id = request.guitarTypeId
            };
            var gotGuitarType = await this.queryExecutor.Execute(query);
            if(gotGuitarType == null)
                return new UpdateGuitarTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            var command = new UpdateGuitarTypeCommand()
            {
                Parameter = this.mapper.Map(request, gotGuitarType)
            };
            var updatedGuitarType = await this.commandExecutor.Execute(command);
            return new UpdateGuitarTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.GuitarType>(updatedGuitarType)
            };
        }
    }
}
