using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.StringInSet;

namespace GuitarManager.ApplicationServices.API.Validators.StringInSet
{
    public class AddStringInSetRequestValidator : AbstractValidator<AddStringInSetRequest>
    {
        public AddStringInSetRequestValidator()
        {
            RuleFor(x => x.StringPosition).NotEmpty();

            RuleFor(x => x.StringID).NotEmpty();

            RuleFor(x => x.StringSetID).NotEmpty();
        }
    }
}
