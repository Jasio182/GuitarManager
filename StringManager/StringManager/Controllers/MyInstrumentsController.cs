using GuitarManager.ApplicationServices.API.Domain.MyInstrument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MyInstrumentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public MyInstrumentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMyInstruments([FromQuery] GetMyInstrumentsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddMyInstrument([FromBody] AddMyInstrumentRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{MyInstrumentId}")]
        public async Task<IActionResult> GetMyInstrumentById([FromRoute] GetMyInstrumentByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }

        [HttpDelete]
        [Route("{MyInstrumentId}")]
        public async Task<IActionResult> RemoveMyInstrument([FromRoute] RemoveMyInstrumentRequest request)
        {
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
