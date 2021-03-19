using GuitarManager.ApplicationServices.API.Domain.StringType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStringTypes([FromQuery] GetStringTypesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddStringType([FromBody] AddStringTypeRequest request)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{stringTypeId}")]
        public async Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringTypeRequest request, int stringTypeId)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            request.stringTypeId = stringTypeId;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
