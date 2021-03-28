using GuitarManager.ApplicationServices.API.Domain.StringSet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringSetsController : ApiControllerBase
    {
        public StringSetsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllStringSets([FromQuery] GetStringSetsRequest request)
        {
            return this.HandleRequest<GetStringSetsRequest, GetStringSetsResponse>(request);
        }

        [HttpGet]
        [Route("{StringSetId}")]
        public Task<IActionResult> GetStringSetById([FromRoute] GetStringSetByIdRequest request)
        {
            return this.HandleRequest<GetStringSetByIdRequest, GetStringSetByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddStringSet([FromBody] AddStringSetRequest request)
        {
            return this.HandleRequest<AddStringSetRequest, AddStringSetResponse>(request);
        }

        [HttpPut]
        [Route("{stringSetId}")]
        public Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringSetRequest request, int stringSetId)
        {
            request.stringSetId = stringSetId;
            return this.HandleRequest<UpdateStringSetRequest, UpdateStringSetResponse>(request);
        }
    }
}
