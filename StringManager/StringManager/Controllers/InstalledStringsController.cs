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
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddInstalledString([FromBody] AddInstalledStringRequest request)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{StringPosition}/{MyInstrumentID}")]
        public async Task<IActionResult> RemoveInstalledString([FromRoute] RemoveInstalledStringRequest request)
        {
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok();
        }

        [HttpPut]
        [Route("{stringPosition}/{myInstrumentID}")]
        public async Task<IActionResult> UpdateInstalledString([FromBody] UpdateInstalledStringRequest request, int myInstrumentID, int stringPosition)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            request.routeMyInstrumentID = myInstrumentID;
            request.routeStringPosition = stringPosition;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
