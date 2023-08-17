using Data.Context;
using Entities.Request;
using FluentValidation;

namespace Business.Validations
{
    public class CreateUserValidations : AbstractValidator<CreateUserRequest>
    {
       private readonly ClinicContext _db;
       public CreateUserValidations(ClinicContext db) {
            _db = db;

            RuleFor(c => c.Active)
                .NotNull()
                .WithMessage("El campo activo es obligatorio");
            RuleFor(c => c.Reset)
                .NotNull()
                .WithMessage("El campo reestablecer es obligatorio");
            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("El campo numero no puede ser vacio")
                .Matches(@"^[0-9]{8}$")
                .WithMessage("El número de teléfono debe tener 8 dígitos y contener solo números");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("El campo correo es obligatorio")
                .EmailAddress()
                .WithMessage("El Correo ingresado no es valido");
            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("El Nombre no puede ser vacio");
            RuleFor(c => c.RolId)
                .NotEmpty()
                .WithMessage("El rol no puede ser vacio")
                .Must(rol => ExistRol(rol))
                .WithMessage("El rol no existe");
            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("La contraseña no puede ser vacia");
       }

       private bool ExistRol(int idRol)
            => _db.Roles.Any(u => u.Id == idRol);
            
    }
}
