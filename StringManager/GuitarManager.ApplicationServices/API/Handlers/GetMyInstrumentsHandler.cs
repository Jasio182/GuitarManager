using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetMyInstrumentsHandler : IRequestHandler<GetMyInstrumentsRequest, GetMyInstrumentsResponse>
    {
        private readonly IRepository<MyInstrument> myInstrumentsRepository;

        public GetMyInstrumentsHandler(IRepository<MyInstrument> myInstrumentsRepository)
        {
            this.myInstrumentsRepository = myInstrumentsRepository;
        }

        public Task<GetMyInstrumentsResponse> Handle(GetMyInstrumentsRequest request, CancellationToken cancellationToken)
        {
            var myInstruments = this.myInstrumentsRepository.GetAll();
            var domainMyInstruments = myInstruments.Select(x => new Domain.Models.MyInstrument()
            {
                Id = x.Id,
                HoursWeekly = x.HoursWeekly,
                LastStringChange = x.LastStringChange,
                LastDeepCleaning = x.LastDeepCleaning,
                InstrumentID = x.InstrumentID,
                PlayerID = x.PlayerID
            });
            var response = new GetMyInstrumentsResponse()
            {
                Data = domainMyInstruments.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
