using GuitarManager.ApplicationServices.API.Domain;
using GuitarManager.ApplicationServices.API.Domain.StringType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringTypesController : ApiControllerBase
    {
        public StringTypesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllStringTypes([FromQuery] GetStringTypesRequest request)
        {
            return this.HandleRequest<GetStringTypesRequest, GetStringTypesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddStringType([FromBody] AddStringTypeRequest request)
        {
            return this.HandleRequest<AddStringTypeRequest, AddStringTypeResponse>(request);
        }

        [HttpPut]
        [Route("{stringTypeId}")]
        public Task<IActionResult> UpdateMyInstrument([FromBody] UpdateStringTypeRequest request, int stringTypeId)
        {
            request.stringTypeId = stringTypeId;
            return this.HandleRequest<UpdateStringTypeRequest, UpdateStringTypeResponse>(request);
        }
    }
}
