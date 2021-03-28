using GuitarManager.ApplicationServices.API.Domain.Sound;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoundsController : ApiControllerBase
    {
       public SoundsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllSounds([FromQuery] GetSoundsRequest request)
        {
            return this.HandleRequest<GetSoundsRequest, GetSoundsResponse>(request);
        }

        [HttpGet]
        [Route("{SoundId}")]
        public Task<IActionResult> GetSoundsById([FromRoute] GetSoundByIdRequest request)
        {
            return this.HandleRequest<GetSoundByIdRequest, GetSoundByIdResponse>(request);
        }
    }
}