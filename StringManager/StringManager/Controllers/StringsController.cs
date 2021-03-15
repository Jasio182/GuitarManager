using GuitarManager.ApplicationServices.API.Domain.String;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStrings([FromQuery] GetStringsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{StringId}")]
        public async Task<IActionResult> GetStringById([FromRoute] GetStringByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddString([FromBody] AddStringRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{stringId}")]
        public async Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringRequest request, int stringId)
        {
            request.stringId = stringId;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
