using Entities.Request;
using FluentValidation;

namespace Business.Validations
{
    public class LoginValidations : AbstractValidator<LoginRequest>
    {
        public LoginValidations() {
            RuleFor(l => l.Password)
                .NotEmpty().
                WithMessage("La Contraseña no puede ser vacia");
            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("El Correo es obligatorio")
                .EmailAddress()
                .WithMessage("El Correo no es valido fluent");
        }
    }
}
