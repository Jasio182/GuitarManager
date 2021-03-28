using GuitarManager.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GuitarManager.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest <TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }
            var response = await this.mediator.Send(request);
            if(response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }
            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            return errorType switch
            {
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.NotFound => HttpStatusCode.NotFound,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.UnsupportedMethod => HttpStatusCode.MethodNotAllowed,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.Conflict => HttpStatusCode.Conflict,
                ApplicationServices.API.Domain.ErrorHandling.ErrorType.TooManyRequests => (HttpStatusCode)429,
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}
