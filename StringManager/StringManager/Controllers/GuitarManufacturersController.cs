using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarManufacturersController : ControllerBase
    {
        private readonly IMediator mediator;

        public GuitarManufacturersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGuitarManufacturers([FromQuery] GetGuitarManufacturersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddGuitarManufacturer([FromBody] AddGuitarManufacturerRequest request)
        {
            if (this.ModelState.IsValid) 
            {
                return this.BadRequest("BAD_REQUEST");
            }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{guitarManufacturerId}")]
        public async Task<IActionResult> UpdateGuitarManufacturer([FromBody] UpdateGuitarManufacturerRequest request, int guitarManufacturerId)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest("BAD_REQUEST");
            }
            request.guitarManufacturerId = guitarManufacturerId;
            var response = await this.mediator.Send(request);
            if (response.Data == null)
                return this.NotFound();
            else
                return this.Ok(response);
        }
    }
}
