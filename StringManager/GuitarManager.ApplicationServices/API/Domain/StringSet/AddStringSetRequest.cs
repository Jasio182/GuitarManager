using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GuitarManager.ApplicationServices.API.Domain.StringSet
{
    public class AddStringSetRequest : IRequest<AddStringSetResponse>
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int NumberOfStrings { get; set; }

        public int GuitarTypeID { get; set; }
    }
}
