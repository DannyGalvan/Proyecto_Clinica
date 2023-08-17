using Entities.Request;
using FluentValidation;

namespace Business.Validations
{
    public class RecoveryPasswordValidations : AbstractValidator<RecoveryPasswordRequest>
    {
        public RecoveryPasswordValidations() { 
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("El correo es obligatorio")
                .EmailAddress()
                .WithMessage("El correo es invalido");
        }
    }
}
