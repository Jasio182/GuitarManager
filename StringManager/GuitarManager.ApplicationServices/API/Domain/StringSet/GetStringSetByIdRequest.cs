using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.StringSet
{
    public class GetStringSetByIdRequest : IRequest<GetStringSetByIdResponse>
    {
        public int StringSetId { get; set; }
    }
}
