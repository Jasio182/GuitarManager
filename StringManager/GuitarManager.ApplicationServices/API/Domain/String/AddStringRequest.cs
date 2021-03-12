using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.String
{
    public class AddStringRequest : IRequest<AddStringResponse>
    {
        [Required]
        public double Size { get; set; }

        [Required]
        public double BulkDensity { get; set; }

        public int StringTypeID { get; set; }

        public int StringManufacturerID { get; set; }
    }
}
