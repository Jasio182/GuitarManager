using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.Instrument;

namespace GuitarManager.ApplicationServices.API.Validators.Instrument
{
    public class UpdateInstrumentRequestValidator : AbstractValidator<UpdateInstrumentRequest>
    {
        public UpdateInstrumentRequestValidator()
        {
            RuleFor(x => x.Model).Length(0, 300).NotEmpty();

            RuleFor(x => x.NumberOfStrings).NotEmpty();

            RuleFor(x => x.ScaleLenghtBass).NotEmpty();

            RuleFor(x => x.ScaleLenghtTreble).NotEmpty();
        }
    }
}
