using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringManufacturersController : ApiControllerBase
    {
        public StringManufacturersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllStringManufacturers([FromQuery] GetStringManufacturersRequest request)
        {
            return this.HandleRequest<GetStringManufacturersRequest, GetStringManufacturersResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddStringManufacturers([FromBody] AddStringManufacturerRequest request)
        {
            return this.HandleRequest<AddStringManufacturerRequest, AddStringManufacturerResponse>(request);
        }

        [HttpPut]
        [Route("{stringManufacturerId}")]
        public Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringManufacturerRequest request, int stringManufacturerId)
        {
            request.stringManufacturerId = stringManufacturerId;
            return this.HandleRequest<UpdateStringManufacturerRequest, UpdateStringManufacturerResponse>(request);
        }
    }
}
