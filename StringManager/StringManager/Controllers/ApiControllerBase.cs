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
            switch (errorType)
            {
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ApplicationServices.API.Domain.ErrorHandling.ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
