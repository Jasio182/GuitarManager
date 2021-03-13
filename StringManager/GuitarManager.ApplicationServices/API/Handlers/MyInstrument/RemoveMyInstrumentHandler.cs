using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.MyInstrument;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.MyInstrument;
using GuitarManager.DataAccess.CQRS.Queries.MyInstrument;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.MyInstrument
{
    public class RemoveMyInstrumentHandler : IRequestHandler<RemoveMyInstrumentRequest, RemoveMyInstrumentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public RemoveMyInstrumentHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<RemoveMyInstrumentResponse> Handle(RemoveMyInstrumentRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMyInstrumentByIdQuery()
            {
                Id = request.MyInstrumentId
            };
            var myInstrument = await this.queryExecutor.Execute(query);
            if (myInstrument == null)
                return new RemoveMyInstrumentResponse()
                {
                    Data = null
                };
            var command = new RemoveMyInstrumentCommand()
            {
                Parameter = myInstrument
            };
            var removedMyInstrument = await this.commandExecutor.Execute(command);
            return new RemoveMyInstrumentResponse()
            {
                Data = this.mapper.Map<Domain.Models.MyInstrument>(removedMyInstrument)
            };
        }
    }
}
