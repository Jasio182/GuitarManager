using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.StringInSet
{
    public class GetStringInSetByStringSetAndPositionRequest : IRequest<GetStringInSetByStringSetAndPositionResponse>
    {
        public int StringPosition { get; set; }

        public int StringSetID { get; set; }
    }
}
