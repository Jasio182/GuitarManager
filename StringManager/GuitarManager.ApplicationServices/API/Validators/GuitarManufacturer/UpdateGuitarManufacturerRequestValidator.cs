using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.GuitarManufacturer;

namespace GuitarManager.ApplicationServices.API.Validators.GuitarManufacturer
{
    public class UpdateGuitarManufacturerRequestValidator : AbstractValidator<UpdateGuitarManufacturerRequest>
    {
        public UpdateGuitarManufacturerRequestValidator()
        {
            RuleFor(x => x.GuitarManufacturerName).Length(0, 150).NotEmpty();
        }
    }
}
