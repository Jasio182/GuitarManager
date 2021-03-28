using GuitarManager.ApplicationServices.API.Domain.Player;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ApiControllerBase
    {
        public PlayersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllPlayers([FromQuery] GetPlayersRequest request)
        {
            return this.HandleRequest<GetPlayersRequest, GetPlayersResponse>(request);
        }

        [HttpGet]
        [Route("{PlayerId}")]
        public Task<IActionResult> GetPlayerById([FromRoute] GetPlayerByIdRequest request)
        {
            return this.HandleRequest<GetPlayerByIdRequest, GetPlayerByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddPlayer([FromBody] AddPlayerRequest request)
        {
            return this.HandleRequest<AddPlayerRequest, AddPlayerResponse>(request);
        }

        [HttpDelete]
        [Route("{PlayerId}")]
        public Task<IActionResult> RemovePlayer([FromRoute] RemovePlayerRequest request)
        {
            return this.HandleRequest<RemovePlayerRequest, RemovePlayerResponse>(request);
        }

        [HttpPut]
        [Route("{playerId}")]
        public Task<IActionResult> UpdateMyInstrument([FromBody] UpdatePlayerRequest request, int playerId)
        {
            request.playerId = playerId;
            return this.HandleRequest<UpdatePlayerRequest, UpdatePlayerResponse>(request);
        }
    }
}
