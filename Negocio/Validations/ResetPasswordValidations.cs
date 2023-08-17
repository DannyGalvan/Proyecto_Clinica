using Entities.Request;
using FluentValidation;

namespace Business.Validations
{
    public class ResetPasswordValidations : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordValidations() {
            RuleFor(u => u.IdUser)
               .NotEmpty()
               .WithMessage("Debes proporcionar el Id del usuario")
               .Must(Id => Id > 0)
               .WithMessage("El Id debe ser mayor a 0");
            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Debes proporcionar una contraseña")
                .MinimumLength(8)
                .WithMessage("La contraseña debe contener al menos 8 caracteres")
                .Matches("^(?=.*[A-Z])(?=.*\\d).+$")
                .WithMessage("La contraseña debe contener al menos una letra mayúscula un número");
            RuleFor(u => u.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Debes confirmar la contraseña")
                .Equal(u => u.Password)
                .WithMessage("La confirmación de la contraseña debe coincidir con la contraseña");
        }
    }
}
