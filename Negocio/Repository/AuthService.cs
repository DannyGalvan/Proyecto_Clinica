using Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Business.Interfaces;
using Data.Context;
using Entities.DTO;
using Entities.Request;
using Microsoft.EntityFrameworkCore;
using Entities.Response;
using System.Globalization;

namespace Business.Repository
{
    public class AuthService : IAuthService
    {
        private readonly ClinicContextMySQL _bd;
        private readonly AppSettings _appSettings;
        private readonly IMail _mail;

        public AuthService(IOptions<AppSettings> appSettings, ClinicContextMySQL bd, IMail mail)
        {
            _appSettings = appSettings.Value;
            _bd = bd;
            _mail = mail;
        }

        public Response<AuthResponse> Auth(LoginRequest model)
        {
            Response<AuthResponse> userResponse = new();

            string password = Resources.ConvertSha256(model.Password);

            User? oUser = _bd.Users
                             .FirstOrDefault(u => u.Password == password && u.Email == model.Email);

            if (oUser == null || oUser.Active == false)
            {
                userResponse.Success = false;
                userResponse.Message = "Usuario y/o Contraseña Invalidos";
                return userResponse;
            }

            List<Authorizations> authorizations = new();

            Employee? employee = _bd.Employees.Include(e => e.Rol).FirstOrDefault(u => u.UserId == oUser.Id);

            if (employee != null)
            {

                List<RolOperation> rolOperations = _bd.RolOperations.Include(r => r.Operation)
                                                      .Where(r => r.RolId == employee.RolId).ToList();

                List<Operation> operationsRol = rolOperations.Select(ro => new Operation()
                                                                           {
                                                                               Name     = ro.Operation!.Name,
                                                                               IdModule = ro.Operation.IdModule,
                                                                               Id       = ro.Operation.Id,
                                                                               CreatedAt = ro.Operation.CreatedAt,
                                                                               IsVisible = ro.Operation.IsVisible,
                                                                               Icon = ro.Operation.Icon,
                                                                               Path = ro.Operation.Path,
                                                                               Description = ro.Operation.Description
                                                                           }).ToList();

                var modules =
                    _bd.Modules
                       .FromSql(@$"SELECT mo.Id, mo.Name, mo.Description,mo.Image, mo.Path, mo.CreatedAt, mo.CreatedBy, mo.UpdatedAt, mo.UpdatedBy
                                    FROM (SELECT DISTINCT o.IdModule FROM roloperations ro
                                                                              INNER JOIN operations o ON o.Id = ro.OperationId
                                                                              INNER JOIN modules m ON o.IdModule = m.Id) As m
                                    INNER JOIN modules mo ON m.IdModule = mo.Id;").ToList();

                employee.Rol!.RolOperations = rolOperations;

                authorizations = modules.Select(module => new Authorizations() { Module = module, Operations = operationsRol.Where(o => o.IdModule == module.Id).ToList() }).ToList();

            }

            Client? client = employee == null ? _bd.Clients.FirstOrDefault(c => c.UserId == oUser.Id) : null;

            var nameEmployee       = employee != null ? employee.Name : "";
            var nameClient = client != null ? client.Name : "";
            var username   = string.Empty;

            if (!string.IsNullOrEmpty(nameEmployee))
                username = nameEmployee;
            else if (!string.IsNullOrEmpty(nameClient))
                username = nameClient;


            AuthResponse auth = new()
            {
                Email      = oUser.Email,
                IdUser     = oUser.Id,
                Name       = username,
                Rol        = employee?.RolId ?? 0,
                Token      = GetToken(oUser, employee, username),
                Operations = authorizations
            };


            userResponse.Success = true;
            userResponse.Message = "Inicio de sesión exitosa";
            userResponse.Data = auth;

            return userResponse;
        }

        public Response<string> ChangePassword(ChangePasswordRequest model)
        {

            Response<string> response = new();

            User? oUser = _bd.Users.FirstOrDefault(u => u.RecoveryToken == model.Token);

            if (oUser == null || model.Password != model.ConfirmPassword)
            {
                response.Success = false;
                response.Message = "Las Contraseñas no coinciden";
                response.Data = "";
                return response;
            }

            string encrypt = Resources.ConvertSha256(model.Password);

            if (oUser.Password == encrypt)
            {
                response.Success = false;
                response.Message = "La nueva contraseña debe ser distinta a la contraseña anterior";
                response.Data = "";
                return response;
            }

            oUser.Password = encrypt;
            oUser.RecoveryToken = "";
            _bd.Users.Update(oUser);

            int saveChanges = _bd.SaveChanges();

            if (saveChanges == 0)
            {
                response.Success = false;
                response.Message = "Hubo un Error en el Cambio de Contraseña";
                response.Data = "";
                return response;
            }

            response.Success = true;
            response.Message = "Cambio de Contraseña Exitoso";
            response.Data = $"tu nueva contraseña es: {model.Password}";

            return response;
        }

        public Response<string> ResetPassword(ResetPasswordRequest model)
        {

            Response<string> response = new();

            User? oUser = _bd.Users.FirstOrDefault(u => u.Id == model.IdUser);

            if (oUser == null)
            {
                response.Success = false;
                response.Message = "El Usuario no existe";
                response.Data = "";
                return response;
            }

            string encrypt = Resources.ConvertSha256(model.Password);

            oUser.Password = encrypt;
            oUser.RecoveryToken = "";
            oUser.Reset = false;
            _bd.Users.Update(oUser);

            int saveChanges = _bd.SaveChanges();

            if (saveChanges == 0)
            {
                response.Success = false;
                response.Message = "Hubo un error al reestablecer la Contraseña";
                response.Data = "";
                return response;
            }

            response.Success = true;
            response.Message = "Cambio de Contraseña Exitoso";
            response.Data = $"tu nueva contraseña es: {model.Password}";

            return response;
        }

        public Response<string> ValidateToken(string token)
        {

            Response<string> response = new();

            var oUser = _bd.Users.FirstOrDefault(u => u.RecoveryToken == token);

            if (oUser == null)
            {
                response.Success = false;
                response.Message = "Su Token ya ha Expirado";
                response.Data = token;
                return response;
            }

            DateTime? dateToken = !string.IsNullOrEmpty(oUser.DateToken)
                                     ? DateTime.ParseExact(oUser.DateToken, "yyyy-MM-dd mm:ss:f", CultureInfo.InvariantCulture)
                                     : null;

            var currentDate = DateTime.Now;

            if (dateToken != null && currentDate.CompareTo(dateToken) >= 0)
            {
                response.Success = false;
                response.Message = "Tu Token ya ha Expirado";
                response.Data = token;
                return response;
            }

            response.Success = true;
            response.Message = "Token Válido";
            response.Data = token;

            return response;
        }

        public Response<string> RecoveryPassword(RecoveryPasswordRequest model)
        {
            Response<string> response = new();

            Regex email = new(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");

            if (!email.IsMatch(model.Email))
            {
                response.Success = false;
                response.Message = "Ingrese un correo válido";
                response.Data = "";
                return response;
            }

            User? oUser = _bd.Users.FirstOrDefault(u => u.Email == model.Email);

            if (oUser == null)
            {
                response.Success = false;
                response.Message = "Correo no existe";
                response.Data = "";
                return response;
            }

            var token = Resources.ConvertSha256(Guid.NewGuid().ToString());

            oUser.RecoveryToken = token;
            oUser.DateToken = DateTime.Now.ToString("yyyy-MM-dd mm:ss:f");
            _bd.Users.Update(oUser);
            var saveChanges = _bd.SaveChanges();

            if (saveChanges == 0)
            {
                response.Success = false;
                response.Message = "Error al intentar recuperar contraseña";
                response.Data = "";
                return response;
            }

            const string affair = "Solicitud De Cambio de Contraseña";
            var       link   = $"{_appSettings.MailForwarding}/app/RecoveryPassword?token={token}";
            var messageMail =
                $"<h3>Ingese al siguiente link para cambiar su contraseña!</h3></br><a href='{link}'>Cambiar Contraseña</a>";

            var sendMail = _mail.Send(model.Email, affair, messageMail);

            if (!sendMail)
            {
                response.Success = false;
                response.Message = "Error al Enviar Correo";
                response.Data = "";
                return response;
            }

            response.Success = true;
            response.Message = "Correo Enviado Con Exito";
            response.Data = link;

            return response;
        }

        private string GetToken(User user, Employee? employee, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key          = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new List<Claim>()
                             {
                                 new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                                 new (ClaimTypes.Email, user.Email),
                                 new (ClaimTypes.Name, username),
                                 new (ClaimTypes.Hash, Guid.NewGuid().ToString()),
                                 new ("Operator", employee != null ? employee.RolId.ToString() : "Cliente"),
                             };

            if (employee != null && employee.Rol!.RolOperations.Count != 0)
            {
                claims.AddRange(employee.Rol!.RolOperations.Select(item => new Claim(ClaimTypes.Role, item.OperationId.ToString())));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                NotBefore = DateTime.UtcNow.AddMinutes(-5),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials =
                                          new SigningCredentials(new SymmetricSecurityKey(key),
                                                                 SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
