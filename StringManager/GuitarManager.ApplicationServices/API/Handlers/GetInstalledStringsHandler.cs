using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetInstalledStringsHandler : IRequestHandler<GetInstalledStringsRequest, GetInstalledStringsResponse>
    {
        private readonly IRepository<InstalledString> installedStringsRepository;

        public GetInstalledStringsHandler(IRepository<InstalledString> installedStringsRepository)
        {
            this.installedStringsRepository = installedStringsRepository;
        }
        public Task<GetInstalledStringsResponse> Handle(GetInstalledStringsRequest request, CancellationToken cancellationToken)
        {
            var installedStrings = installedStringsRepository.GetAll();
            var domainInstalledStrings = installedStrings.Select(x => new Domain.Models.InstalledString()
            {
                StringPosition = x.StringPosition,
                SoundID = x.SoundID,
                StringID = x.StringID,
                MyInstrumentID = x.MyInstrumentID
            });
            var response = new GetInstalledStringsResponse()
            {
                Data = domainInstalledStrings.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
