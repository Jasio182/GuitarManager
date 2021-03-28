using GuitarManager.ApplicationServices.API.Domain.InstalledString;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstalledStringsController : ApiControllerBase
    {
        public InstalledStringsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllInstalledStrings([FromQuery] GetInstalledStringsRequest request)
        {
            return this.HandleRequest<GetInstalledStringsRequest, GetInstalledStringsResponse>(request);
        }

        [HttpGet]
        [Route("{StringPosition}/{MyInstrumentID}")]
        public Task<IActionResult> GetInstalledStringByPositionAndMyInstrument([FromRoute] GetInstalledStringByPositionAndMyInstrumentRequest request)
        {
            return this.HandleRequest<GetInstalledStringByPositionAndMyInstrumentRequest, GetInstalledStringByPositionAndMyInstrumentResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddInstalledString([FromBody] AddInstalledStringRequest request)
        {
            return this.HandleRequest<AddInstalledStringRequest, AddInstalledStringResponse>(request);
        }

        [HttpDelete]
        [Route("{StringPosition}/{MyInstrumentID}")]
        public Task<IActionResult> RemoveInstalledString([FromRoute] RemoveInstalledStringRequest request)
        {
            return this.HandleRequest<RemoveInstalledStringRequest, RemoveInstalledStringResponse>(request);
        }

        [HttpPut]
        [Route("{stringPosition}/{myInstrumentID}")]
        public Task<IActionResult> UpdateInstalledString([FromBody] UpdateInstalledStringRequest request, int myInstrumentID, int stringPosition)
        {
            request.routeMyInstrumentID = myInstrumentID;
            request.routeStringPosition = stringPosition;
            return this.HandleRequest<UpdateInstalledStringRequest, UpdateInstalledStringResponse>(request);
        }
    }
}
