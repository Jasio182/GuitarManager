using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.String;

namespace GuitarManager.ApplicationServices.API.Validators.String
{
    public class UpdateStringRequestValidator : AbstractValidator<UpdateStringRequest>
    {
        public UpdateStringRequestValidator()
        {
            RuleFor(x => x.BulkDensity).NotEmpty();

            RuleFor(x => x.Size).NotEmpty();
        }
    }
}
