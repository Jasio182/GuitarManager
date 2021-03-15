using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.StringInSet
{
    public class UpdateStringInSetRequest : IRequest<UpdateStringInSetResponse>
    {
        public int routeStringPosition;

        public int routeStringSetID;

        public int StringPosition { get; set; }

        public int StringID { get; set; }

        public int StringSetID { get; set; }
    }
}
