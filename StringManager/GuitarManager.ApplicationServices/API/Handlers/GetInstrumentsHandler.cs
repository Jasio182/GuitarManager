using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetInstrumentsHandler : IRequestHandler<GetInstrumentsRequest, GetInstrumentsResponse>
    {
        private readonly IRepository<Instrument> instrumentsRepository;

        public GetInstrumentsHandler(IRepository<Instrument> instrumentsRepository)
        {
            this.instrumentsRepository = instrumentsRepository;
        }


        public Task<GetInstrumentsResponse> Handle(GetInstrumentsRequest request, CancellationToken cancellationToken)
        {
            var instruments = this.instrumentsRepository.GetAll();
            var domainInstruments = instruments.Select(x => new Domain.Models.Instrument()
            {
                Id = x.Id,
                Model = x.Model,
                NumberOfStrings = x.NumberOfStrings,
                ScaleLenghtBass = x.ScaleLenghtBass,
                ScaleLenghtTreble = x.ScaleLenghtTreble,
                GuitarManufacturerID = x.GuitarManufacturerID,
                GuitarTypeID = x.GuitarTypeID
            });
            var response = new GetInstrumentsResponse()
            {
                Data = domainInstruments.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
