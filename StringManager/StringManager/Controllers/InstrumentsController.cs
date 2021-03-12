using GuitarManager.ApplicationServices.API.Domain.Instrument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public InstrumentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInstruments([FromQuery] GetInstrumentsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{InstrumentId}")]
        public async Task<IActionResult> GetInstrumentById([FromRoute] GetInstrumentByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
