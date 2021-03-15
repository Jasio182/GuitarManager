using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringManufacturersController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringManufacturersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStringManufacturers([FromQuery] GetStringManufacturersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddStringManufacturers([FromBody] AddStringManufacturerRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{stringManufacturerId}")]
        public async Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringManufacturerRequest request, int stringManufacturerId)
        {
            request.stringManufacturerId = stringManufacturerId;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
