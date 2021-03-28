using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsInSetsController : ApiControllerBase
    {
        public StringsInSetsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllStringsInSets([FromQuery] GetStringsInSetsRequest request)
        {
            return this.HandleRequest<GetStringsInSetsRequest, GetStringsInSetsResponse>(request);
        }

        [HttpGet]
        [Route("{StringPosition}/{StringSetID}")]
        public Task<IActionResult> GetStringInSetByStringSetAndPosition([FromRoute] GetStringInSetByStringSetAndPositionRequest request)
        {
            return this.HandleRequest<GetStringInSetByStringSetAndPositionRequest, GetStringInSetByStringSetAndPositionResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddStringInSet([FromBody] AddStringInSetRequest request)
        {
            return this.HandleRequest<AddStringInSetRequest, AddStringInSetResponse>(request);
        }

        [HttpDelete]
        [Route("{StringPosition}/{StringSetID}")]
        public Task<IActionResult> RemoveStringInSet([FromRoute] RemoveStringInSetRequest request)
        {
            return this.HandleRequest<RemoveStringInSetRequest, RemoveStringInSetResponse>(request);
        }

        [HttpPut]
        [Route("{stringPosition}/{stringSetID}")]
        public Task<IActionResult> UpdateInstalledString([FromBody] UpdateStringInSetRequest request, int stringSetID, int stringPosition)
        {
            request.routeStringSetID = stringSetID;
            request.routeStringPosition = stringPosition;
            return this.HandleRequest<UpdateStringInSetRequest, UpdateStringInSetResponse>(request);
        }
    }
}
