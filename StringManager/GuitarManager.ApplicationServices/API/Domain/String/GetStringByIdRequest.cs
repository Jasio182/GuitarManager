using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.String
{
    public class GetStringByIdRequest : IRequest<GetStringByIdResponse>
    {
        public int StringId { get; set; }
    }
}
