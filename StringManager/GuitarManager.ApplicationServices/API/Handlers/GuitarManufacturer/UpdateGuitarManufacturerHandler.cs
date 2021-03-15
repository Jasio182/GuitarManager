using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.GuitarManufacturer;
using GuitarManager.DataAccess.CQRS.Queries.GuitarManufacturer;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.GuitarManufacturer
{
    public class UpdateGuitarManufacturerHandler : IRequestHandler<UpdateGuitarManufacturerRequest, UpdateGuitarManufacturerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateGuitarManufacturerHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateGuitarManufacturerResponse> Handle(UpdateGuitarManufacturerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetGuitarManufacturerByIdQuery()
            {
                Id = request.guitarManufacturerId
            };
            var gotGuitarManufacturer = await this.queryExecutor.Execute(query);
            if (gotGuitarManufacturer == null)
                return new UpdateGuitarManufacturerResponse()
                {
                    Data = null
                };
            var command = new UpdateGuitarManufacturerCommand()
            {
                Parameter = this.mapper.Map(request, gotGuitarManufacturer)
            };
            var updatedGuitarManufacturer = await this.commandExecutor.Execute(command);
            return new UpdateGuitarManufacturerResponse()
            {
                Data = mapper.Map<Domain.Models.GuitarManufacturer>(updatedGuitarManufacturer)
            };
        }
    }
}
