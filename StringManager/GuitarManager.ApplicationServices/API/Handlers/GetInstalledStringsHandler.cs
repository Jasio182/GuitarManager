using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetInstalledStringsHandler : IRequestHandler<GetInstalledStringsRequest, GetInstalledStringsResponse>
    {
        private readonly IRepository<InstalledString> installedStringsRepository;
        private readonly IMapper mapper;

        public GetInstalledStringsHandler(IRepository<InstalledString> installedStringsRepository, IMapper mapper)
        {
            this.installedStringsRepository = installedStringsRepository;
            this.mapper = mapper;
        }
        public Task<GetInstalledStringsResponse> Handle(GetInstalledStringsRequest request, CancellationToken cancellationToken)
        {
            var installedStrings = installedStringsRepository.GetAll();
            var mappedInstalledStrings = this.mapper.Map<List<Domain.Models.InstalledString>>(installedStrings);
            var response = new GetInstalledStringsResponse()
            {
                Data = mappedInstalledStrings
            };
            return Task.FromResult(response);
        }
    }
}
