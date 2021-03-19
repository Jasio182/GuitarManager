using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.GuitarType;

namespace GuitarManager.ApplicationServices.API.Validators.GuitarType
{
    public class AddGuitarTypeRequestValidator : AbstractValidator<AddGuitarTypeRequest>
    {
        public AddGuitarTypeRequestValidator()
        {
            RuleFor(x => x.Type).Length(0, 300).NotEmpty();
        }
    }
}
