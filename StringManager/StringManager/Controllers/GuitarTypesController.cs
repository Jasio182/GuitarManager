using GuitarManager.ApplicationServices.API.Domain.GuitarType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public GuitarTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSounds([FromQuery] GetGuitarTypesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
