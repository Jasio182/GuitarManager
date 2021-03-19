using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.StringManufacturer;

namespace GuitarManager.ApplicationServices.API.Validators.StringManufacturer
{
    public class AddStringManufacturerRequestValidator : AbstractValidator<AddStringManufacturerRequest>
    {
        public AddStringManufacturerRequestValidator()
        {
            RuleFor(x => x.StringManufacturerName).Length(0, 150).NotEmpty();
        }
    }
}
