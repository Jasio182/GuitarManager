using GuitarManager.ApplicationServices.API.Domain.StringSet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringSetsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringSetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStringSets([FromQuery] GetStringSetsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{StringSetId}")]
        public async Task<IActionResult> GetStringSetById([FromRoute] GetStringSetByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddStringSet([FromBody] AddStringSetRequest request)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{stringSetId}")]
        public async Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringSetRequest request, int stringSetId)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            request.stringSetId = stringSetId;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
