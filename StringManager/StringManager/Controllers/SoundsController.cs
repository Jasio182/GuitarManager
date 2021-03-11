using GuitarManager.ApplicationServices.API.Domain.Sound;
using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoundsController : ControllerBase
    {
        private readonly IMediator mediator;

       public SoundsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSounds([FromQuery] GetSoundsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{SoundId}")]
        public async Task<IActionResult> GetSoundsById([FromRoute] GetSoundByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}