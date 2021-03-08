using GuitarManager.ApplicationServices.API.Domain;
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
            return this.Ok(request);
        }
    }
}
