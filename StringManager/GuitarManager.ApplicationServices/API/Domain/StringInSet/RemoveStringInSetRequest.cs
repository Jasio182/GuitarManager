using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.StringInSet
{
    public class RemoveStringInSetRequest:IRequest<RemoveStringInSetResponse>
    {
        public int StringPosition { get; set; }

        public int StringSetID { get; set; }
    }
}
