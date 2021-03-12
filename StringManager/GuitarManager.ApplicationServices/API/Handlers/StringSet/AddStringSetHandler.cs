using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.StringSet;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Commands.StringSet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.StringSet
{
    public class AddStringSetHandler : IRequestHandler<AddStringSetRequest, AddStringSetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddStringSetHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddStringSetResponse> Handle(AddStringSetRequest request, CancellationToken cancellationToken)
        {
            var stringSet = this.mapper.Map<DataAccess.Entities.StringSet>(request);
            var command = new AddStringSetCommand()
            {
                Parameter = stringSet
            };
            var stringSetFromDb = await this.commandExecutor.Execute(command);
            return new AddStringSetResponse()
            {
                Data = mapper.Map<Domain.Models.StringSet>(stringSetFromDb)
            };
        }
    }
}
