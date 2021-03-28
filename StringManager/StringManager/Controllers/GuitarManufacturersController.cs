using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarManufacturersController : ApiControllerBase
    {
        public GuitarManufacturersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllGuitarManufacturers([FromQuery] GetGuitarManufacturersRequest request)
        {
            return this.HandleRequest<GetGuitarManufacturersRequest, GetGuitarManufacturersResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddGuitarManufacturer([FromBody] AddGuitarManufacturerRequest request)
        {
            return this.HandleRequest<AddGuitarManufacturerRequest, AddGuitarManufacturerResponse>(request);
        }

        [HttpPut]
        [Route("{guitarManufacturerId}")]
        public Task<IActionResult> UpdateGuitarManufacturer([FromBody] UpdateGuitarManufacturerRequest request, int guitarManufacturerId)
        {
            request.guitarManufacturerId = guitarManufacturerId;
            return this.HandleRequest<UpdateGuitarManufacturerRequest, UpdateGuitarManufacturerResponse>(request);
        }
    }
}
