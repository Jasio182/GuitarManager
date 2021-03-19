using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.StringSet;

namespace GuitarManager.ApplicationServices.API.Validators.StringSet
{
    public class AddStringSetRequestValidator : AbstractValidator<AddStringSetRequest>
    {
        public AddStringSetRequestValidator()
        {
            RuleFor(x => x.NumberOfStrings).NotEmpty();
            RuleFor(x => x.Name).Length(0, 200);
        }
    }
}
