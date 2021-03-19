using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;

namespace GuitarManager.ApplicationServices.API.Validators.StringManufacturer
{
    public class UpdateStringManufacturerRequestValidator : AbstractValidator<UpdateStringManufacturerRequest>
    {
        public UpdateStringManufacturerRequestValidator()
        {
            RuleFor(x => x.StringManufacturerName).Length(0, 150).NotEmpty();
        }
    }
}
