using GuitarManager.ApplicationServices.API.Domain.InstalledString;
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
    public class InstalledStringsController : ControllerBase
    {
        private readonly IMediator mediator;

        public InstalledStringsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInstalledStrings([FromQuery] GetInstalledStringsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{StringPosition}/{MyInstrumentID}")]
        public async Task<IActionResult> GetInstalledStringByPositionAndMyInstrument([FromRoute] GetInstalledStringByPositionAndMyInstrumentRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddInstalledString([FromBody] AddInstalledStringRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
