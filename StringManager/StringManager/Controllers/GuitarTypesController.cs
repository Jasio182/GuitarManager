using GuitarManager.ApplicationServices.API.Domain.GuitarType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarTypesController : ApiControllerBase
    {
        public GuitarTypesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllGuitarTypes([FromQuery] GetGuitarTypesRequest request)
        {
            return this.HandleRequest<GetGuitarTypesRequest, GetGuitarTypesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddGuitarType([FromBody] AddGuitarTypeRequest request)
        {
            return this.HandleRequest<AddGuitarTypeRequest, AddGuitarTypeResponse>(request);
        }

        [HttpPut]
        [Route("{guitarTypeId}")]
        public Task<IActionResult> UpdateGuitarType([FromBody] UpdateGuitarTypeRequest request, int guitarTypeId)
        {
            request.guitarTypeId = guitarTypeId;
            return this.HandleRequest<UpdateGuitarTypeRequest, UpdateGuitarTypeResponse>(request);
        }
    }
}
