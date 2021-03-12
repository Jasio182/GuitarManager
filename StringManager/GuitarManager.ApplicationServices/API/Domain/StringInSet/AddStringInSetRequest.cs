using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.StringInSet
{
    public class AddStringInSetRequest : IRequest<AddStringInSetResponse>
    {
        public int StringPosition { get; set; }

        public int StringID { get; set; }

        public int StringSetID { get; set; }
    }
}
