using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.String;

namespace GuitarManager.ApplicationServices.API.Validators.String
{
    public class AddStringRequestValidator : AbstractValidator<AddStringRequest>
    {
        public AddStringRequestValidator()
        {
            RuleFor(x => x.BulkDensity).NotEmpty();

            RuleFor(x => x.Size).NotEmpty();
        }
    }
}
