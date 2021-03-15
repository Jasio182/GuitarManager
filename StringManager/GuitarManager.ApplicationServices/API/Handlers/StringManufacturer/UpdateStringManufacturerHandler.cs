using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringManufacturer;
using GuitarManager.DataAccess.CQRS.Queries.StringManufacturer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringManufacturer
{
    public class UpdateStringManufacturerHandler : IRequestHandler<UpdateStringManufacturerRequest, UpdateStringManufacturerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateStringManufacturerHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateStringManufacturerResponse> Handle(UpdateStringManufacturerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetStringManufacturerByIdQuery()
            {
                Id = request.stringManufacturerId
            };
            var gotStringManufacturer = await this.queryExecutor.Execute(query);
            if (gotStringManufacturer == null)
                return new UpdateStringManufacturerResponse()
                {
                    Data = null
                };
            var command = new UpdateStringManufacturerCommand()
            {
                Parameter = this.mapper.Map(request, gotStringManufacturer)
            };
            var stringManufacturer = await this.commandExecutor.Execute(command);
            return new UpdateStringManufacturerResponse()
            {
                Data = this.mapper.Map<Domain.Models.StringManufacturer>(stringManufacturer)
            };
        }
    }
}
