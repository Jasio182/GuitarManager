using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.CQRS;
using GuitarManager.DataAccess.CQRS.Queries.InstalledString;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers.InstalledString
{
    public class GetInstalledStringsHandler : IRequestHandler<GetInstalledStringsRequest, GetInstalledStringsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInstalledStringsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInstalledStringsResponse> Handle(GetInstalledStringsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInstalledStringsQuery();
            var installedStrings = await queryExecutor.Execute(query);
            var mappedInstalledStrings = mapper.Map<List<Domain.Models.InstalledString>>(installedStrings);
            var response = new GetInstalledStringsResponse()
            {
                Data = mappedInstalledStrings
            };
            return response;
        }
    }
}
