using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.StringType;

namespace GuitarManager.ApplicationServices.API.Validators.StringType
{
    public class AddStringTypeRequestValidator : AbstractValidator<AddStringTypeRequest>
    {
        public AddStringTypeRequestValidator()
        {
            RuleFor(x => x.Type).Length(0, 300).NotEmpty();
        }
    }
}
