using GuitarManager.ApplicationServices.API.Domain.MyInstrument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MyInstrumentsController : ApiControllerBase
    {
        public MyInstrumentsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllMyInstruments([FromQuery] GetMyInstrumentsRequest request)
        {
            return this.HandleRequest<GetMyInstrumentsRequest, GetMyInstrumentsResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddMyInstrument([FromBody] AddMyInstrumentRequest request)
        {
            return this.HandleRequest<AddMyInstrumentRequest, AddMyInstrumentResponse>(request);
        }

        [HttpGet]
        [Route("{MyInstrumentId}")]
        public Task<IActionResult> GetMyInstrumentById([FromRoute] GetMyInstrumentByIdRequest request)
        {
            return this.HandleRequest<GetMyInstrumentByIdRequest, GetMyInstrumentByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{MyInstrumentId}")]
        public Task<IActionResult> RemoveMyInstrument([FromRoute] RemoveMyInstrumentRequest request)
        {
            return this.HandleRequest<RemoveMyInstrumentRequest, RemoveMyInstrumentResponse>(request);
        }

        [HttpPut]
        [Route("{myInstrumentId}")]
        public Task<IActionResult> UpdateMyInstrument([FromBody] UpdateMyInstrumentRequest request, int myInstrumentId)
        {
            request.myInstrumentId = myInstrumentId;
            return this.HandleRequest<UpdateMyInstrumentRequest, UpdateMyInstrumentResponse>(request);
        }
    }
}
