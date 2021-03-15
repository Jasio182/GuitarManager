using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.StringType
{
    public class UpdateStringTypeRequest : IRequest<UpdateStringTypeResponse>
    {
        public int stringTypeId;

        [MaxLength(300)]
        public string Type { get; set; }
    }
}
