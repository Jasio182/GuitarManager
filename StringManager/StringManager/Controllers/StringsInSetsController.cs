using GuitarManager.ApplicationServices.API.Domain.StringInSet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsInSetsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringsInSetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStringsInSets([FromQuery] GetStringsInSetsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
