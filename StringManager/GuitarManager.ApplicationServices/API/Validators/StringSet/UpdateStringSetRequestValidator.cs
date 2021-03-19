using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.StringSet;

namespace GuitarManager.ApplicationServices.API.Validators.StringSet
{
    public class UpdateStringSetRequestValidator : AbstractValidator<UpdateStringSetRequest>
    {
        public UpdateStringSetRequestValidator()
        {
            RuleFor(x => x.NumberOfStrings).NotEmpty();
            RuleFor(x => x.Name).Length(0, 200);
        }
    }
}
