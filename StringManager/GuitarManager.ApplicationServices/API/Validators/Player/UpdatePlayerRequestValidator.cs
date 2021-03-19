using FluentValidation;
using GuitarManager.ApplicationServices.API.Domain.Player;

namespace GuitarManager.ApplicationServices.API.Validators.Player
{
    public class UpdatePlayerRequestValidator : AbstractValidator<UpdatePlayerRequest>
    {
        public UpdatePlayerRequestValidator()
        {
            RuleFor(x => x.CareStyle).NotEmpty();

            RuleFor(x => x.PlayStyle).NotEmpty();
        }
    }
}

