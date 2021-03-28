using GuitarManager.ApplicationServices.API.Domain.String;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsController : ApiControllerBase
    {
        public StringsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllStrings([FromQuery] GetStringsRequest request)
        {
            return this.HandleRequest<GetStringsRequest, GetStringsResponse>(request);
        }

        [HttpGet]
        [Route("{StringId}")]
        public Task<IActionResult> GetStringById([FromRoute] GetStringByIdRequest request)
        {
            return this.HandleRequest<GetStringByIdRequest, GetStringByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddString([FromBody] AddStringRequest request)
        {
            return this.HandleRequest<AddStringRequest, AddStringResponse>(request);
        }

        [HttpPut]
        [Route("{stringId}")]
        public Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringRequest request, int stringId)
        {
            request.stringId = stringId;
            return this.HandleRequest<UpdateStringRequest, UpdateStringResponse>(request);
        }
    }
}
