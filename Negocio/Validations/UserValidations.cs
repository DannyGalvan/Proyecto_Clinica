using Data.Context;
using Entities.Request;
using FluentValidation;

namespace Business.Validations
{
    public class UserValidations : AbstractValidator<UserRequest>
    {
        private readonly ClinicContext _db;
        public UserValidations(ClinicContext db) { 
            _db = db;
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("Debes proporcionar el Id del usuario")
                .Must(Id => Id > 0)
                .WithMessage("El Id debe ser mayor a 0");
            RuleFor(u => u.Active)
                .NotEmpty()
                .WithMessage("Indica si el usuario esta activo o no");
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Debes proporcionar el correo del usuario")
                .EmailAddress()
                .WithMessage("El correo proporcionado no es valido");
            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("El campo numero no puede ser vacio")
                .Matches(@"^[0-9]{8}$")
                .WithMessage("El número de teléfono debe tener 8 dígitos y contener solo números");
            RuleFor(c => c.RolId)
              .NotEmpty()
              .WithMessage("El rol no puede ser vacio")
              .Must(rol => ExistRol(rol))
              .WithMessage("El rol no existe");
        }

        private bool ExistRol(int idRol)
           => _db.Roles.Any(u => u.Id == idRol);
    }
}
