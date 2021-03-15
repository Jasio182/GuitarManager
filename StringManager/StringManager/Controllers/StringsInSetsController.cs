using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsInSetsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringsInSetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStringsInSets([FromQuery] GetStringsInSetsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{StringPosition}/{StringSetID}")]
        public async Task<IActionResult> GetStringInSetByStringSetAndPosition([FromRoute] GetStringInSetByStringSetAndPositionRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddStringInSet([FromBody] AddStringInSetRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{StringPosition}/{StringSetID}")]
        public async Task<IActionResult> RemoveStringInSet([FromRoute] RemoveStringInSetRequest request)
        {
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok();
        }

        [HttpPut]
        [Route("{stringPosition}/{stringSetID}")]
        public async Task<IActionResult> UpdateInstalledString([FromBody] UpdateStringInSetRequest request, int stringSetID, int stringPosition)
        {
            request.routeStringSetID = stringSetID;
            request.routeStringPosition = stringPosition;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
