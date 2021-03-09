using GuitarManager.ApplicationServices.API.Domain;
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
        private readonly IRepository<Sound> soundRepository;
        private readonly IMediator mediator;

       public SoundsController(IRepository<Sound> soundRepository, IMediator mediator)
        {
            this.soundRepository = soundRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSounds([FromQuery] GetSoundsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        //[HttpGet]
        //[Route("{soundId}")]
        //public Sound GetSoundsById(int soundId) => this.soundRepository.GetById(soundId);
    }
}