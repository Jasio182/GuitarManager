using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.Player;

namespace GuitarManager.ApplicationServices.API.Validators.Player
{
    public class AddPlayerRequestValidator : AbstractValidator<AddPlayerRequest>
    {
        public AddPlayerRequestValidator()
        {
            RuleFor(x => x.CareStyle).NotEmpty();

            RuleFor(x => x.PlayStyle).NotEmpty();
        }
    }
}
