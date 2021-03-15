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
    class UpdateMyInstrumentHandler : IRequestHandler<UpdateMyInstrumentRequest, UpdateMyInstrumentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateMyInstrumentHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateMyInstrumentResponse> Handle(UpdateMyInstrumentRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMyInstrumentByIdQuery()
            {
                Id = request.myInstrumentId
            };
            var gotMyInstrument = await this.queryExecutor.Execute(query);
            if (gotMyInstrument == null)
                return new UpdateMyInstrumentResponse()
                {
                    Data = null
                };
            var command = new UpdateMyInstrumentCommand()
            {
                Parameter = this.mapper.Map(request, gotMyInstrument)
            };
            var myInstrument = await this.commandExecutor.Execute(command);
            return new UpdateMyInstrumentResponse()
            {
                Data = this.mapper.Map<Domain.Models.MyInstrument>(myInstrument)
            };
        }
    }
}
