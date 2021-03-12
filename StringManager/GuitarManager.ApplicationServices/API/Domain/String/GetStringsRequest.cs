using MediatR;

namespace GuitarManager.ApplicationServices.API.Domain.String
{
    public class GetStringsRequest : IRequest<GetStringsResponse>
    {
        public int StringTypeID { get; set; }

        public int StringManufacturerID { get; set; }
    }
}
