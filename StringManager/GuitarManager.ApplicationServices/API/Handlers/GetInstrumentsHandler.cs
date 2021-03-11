using AutoMapper;
using GuitarManager.ApplicationServices.API.Domain.Instrument;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuitarManager.ApplicationServices.API.Handlers
{
    public class GetInstrumentsHandler : IRequestHandler<GetInstrumentsRequest, GetInstrumentsResponse>
    {
        private readonly IRepository<Instrument> instrumentsRepository;
        private readonly IMapper mapper;

        public GetInstrumentsHandler(IRepository<Instrument> instrumentsRepository, IMapper mapper)
        {
            this.instrumentsRepository = instrumentsRepository;
            this.mapper = mapper;
        }


        public async Task<GetInstrumentsResponse> Handle(GetInstrumentsRequest request, CancellationToken cancellationToken)
        {
            var instruments = await this.instrumentsRepository.GetAll();
            var mappedInstruments = this.mapper.Map<List<Domain.Models.Instrument>>(instruments);
            var response = new GetInstrumentsResponse()
            {
                Data = mappedInstruments
            };
            return response;
        }
    }
}
