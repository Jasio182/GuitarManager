using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;

namespace GuitarManager.ApplicationServices.API.Validators.GuitarManufacturer
{
    public class AddGuitarManufacturerRequestValidator : AbstractValidator<AddGuitarManufacturerRequest>
    {
        public AddGuitarManufacturerRequestValidator()
        {
            RuleFor(x => x.GuitarManufacturerName).Length(0, 150).NotEmpty();
        }
    }
}
