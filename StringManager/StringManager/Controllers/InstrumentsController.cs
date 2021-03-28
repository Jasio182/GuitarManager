using GuitarManager.ApplicationServices.API.Domain.Instrument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentsController : ApiControllerBase
    {
        public InstrumentsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllInstruments([FromQuery] GetInstrumentsRequest request)
        {
            return this.HandleRequest<GetInstrumentsRequest, GetInstrumentsResponse>(request);
        }

        [HttpGet]
        [Route("{InstrumentId}")]
        public Task<IActionResult> GetInstrumentById([FromRoute] GetInstrumentByIdRequest request)
        {
            return this.HandleRequest<GetInstrumentByIdRequest, GetInstrumentByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddInstrument([FromBody] AddInstrumentRequest request)
        {
            return this.HandleRequest<AddInstrumentRequest, AddInstrumentResponse>(request);
        }

        [HttpPut]
        [Route("{instrumentId}")]
        public Task<IActionResult> GetInstrumentById([FromBody] UpdateInstrumentRequest request, int instrumentId)
        {
            request.instrumentId = instrumentId;
            return this.HandleRequest<UpdateInstrumentRequest, UpdateInstrumentResponse>(request);
        }
    }
}
