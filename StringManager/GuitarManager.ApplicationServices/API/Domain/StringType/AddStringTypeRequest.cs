using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.StringType
{
    public class AddStringTypeRequest : IRequest<AddStringTypeResponse>
    {
        [MaxLength(300)]
        public string Type { get; set; }
    }
}
