using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.MyInstrument;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetMyInstrumentsHandler : IRequestHandler<GetMyInstrumentsRequest, GetMyInstrumentsResponse>
    {
        private readonly IRepository<MyInstrument> myInstrumentsRepository;
        private readonly IMapper mapper;

        public GetMyInstrumentsHandler(IRepository<MyInstrument> myInstrumentsRepository, IMapper mapper)
        {
            this.myInstrumentsRepository = myInstrumentsRepository;
            this.mapper = mapper;
        }

        public async Task<GetMyInstrumentsResponse> Handle(GetMyInstrumentsRequest request, CancellationToken cancellationToken)
        {
            var myInstruments = await this.myInstrumentsRepository.GetAll();
            var mappedMyInstruments = this.mapper.Map<List<Domain.Models.MyInstrument>>(myInstruments);
            var response = new GetMyInstrumentsResponse()
            {
                Data = mappedMyInstruments
            };
            return response;
        }
    }
}
