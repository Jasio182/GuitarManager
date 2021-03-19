using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.InstalledString;

namespace GuitarManager.ApplicationServices.API.Validators.InstalledString
{
    public class AddInstalledStringRequestValidator : AbstractValidator<AddInstalledStringRequest>
    {
        public AddInstalledStringRequestValidator()
        {
            RuleFor(x => x.StringPosition).NotEmpty();

            RuleFor(x => x.MyInstrumentID).NotEmpty();

            RuleFor(x => x.SoundID).NotEmpty();

            RuleFor(x => x.StringID).NotEmpty();
        }
    }
}
