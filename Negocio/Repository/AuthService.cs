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

namespace Business.Repository
{
    public class AuthService : IAuthService
    {
        private readonly ClinicContext _bd;
        private readonly AppSettings _appSettings;
        private readonly IMail _mail;

        public AuthService(IOptions<AppSettings> appSettings, ClinicContext bd, IMail mail)
        {
            _appSettings = appSettings.Value;
            _bd = bd;
            _mail = mail;
        }

        public Response<AuthResponse> Auth(LoginRequest model)
        {
            Response<AuthResponse> userResponse = new();

            string password = Resources.ConvertSha256(model.Password!);

            User? oUser = _bd.Users
                             .Include(u => u.Rol)
                             .FirstOrDefault(u => u.Password == password && u.Email == model.Email);

            if (oUser == null || oUser.Active == false)
            {
                userResponse.Success = false;
                userResponse.Message = "Usuario y/o Contraseña invalidos";
                return userResponse;
            }

            List<RolOperation> rolOperations = _bd.RolOperations.Include(r => r.Operation)
                                               .Where(r => r.IdRol == oUser.RolId).ToList();

            List<Operation> operationsRol = rolOperations.Select(ro => new Operation()
                                                  {
                                                      Name = ro.Operation!.Name,
                                                      IdModule = ro.Operation.IdModule,
                                                      Id = ro.Operation.Id,
                                                  }).ToList();

            var modules =
                _bd.Modules
                   .FromSql(@$"select Id,Name,Description,Image,Path from (select IdModule from RolOperations ro 
                                                                    inner join Operations o on o.Id = ro.IdOperation
                                                                    inner join Modules m on o.IdModule = m.Id
                                                                    group by IdModule) as mod
                                                                    inner join Modules mo on mod.IdModule = mo.Id").ToList();

            oUser.Rol!.RolOperations = rolOperations;

            List<Authorizations> authorizations = modules.Select(module => new Authorizations() { Module = module, Operations = operationsRol.Where(o => o.IdModule == module.Id).ToList() }).ToList();

            AuthResponse auth = new()
            {
                Email = oUser.Email!,
                IdUser = oUser.Id,
                Name = oUser.Name!,
                Rol = oUser.RolId,
                Token = GetToken(oUser),
                Operations = authorizations
            };


            userResponse.Success = true;
            userResponse.Message = "Inicio de sesion exitosa";
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
                response.Message = "Las Contraseñas no Coinciden";
                response.Data = "";
                return response;
            }

            string encrypt = Resources.ConvertSha256(model.Password);

            if (oUser.Password == encrypt)
            {
                response.Success = false;
                response.Message = "La nueva contrseña debe ser distinta a la contraseña anterior";
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

            User? oUser = _bd.Users.FirstOrDefault(u => u.RecoveryToken == token);

            if (oUser == null)
            {
                response.Success = false;
                response.Message = "Su Token ya ha Expirado";
                response.Data = token;
                return response;
            }

            DateTime dateToken = oUser.DateToken.AddMinutes(15);
            DateTime currentDate = DateTime.Now;

            if (currentDate.CompareTo(dateToken) >= 0)
            {
                response.Success = false;
                response.Message = "Tu Token ya ha Expirado";
                response.Data = token;
                return response;
            }

            response.Success = true;
            response.Message = "Token Valido";
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
                response.Message = "Ingrese un correo Valido";
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

            string token = Resources.ConvertSha256(Guid.NewGuid().ToString());

            oUser.RecoveryToken = token;
            oUser.DateToken = DateTime.Now;
            _bd.Users.Update(oUser);
            int saveChanges = _bd.SaveChanges();

            if (saveChanges == 0)
            {
                response.Success = false;
                response.Message = "Error al intentar recuperar contraseña";
                response.Data = "";
                return response;
            }

            string asunto = "Solicitud De Cambio de Contraseña";
            string link = $"{_appSettings.MailForwarding}/app/RecoveryPassword?token={token}";
            string messageMail =
                $"<h3>Ingese al siguiente link para cambiar su contraseña!</h3></br><a href='{link}'>Cambiar Contraseña</a>";

            var sendMail = _mail.Send(model.Email, asunto, messageMail);

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

        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
            var claims = new List<Claim>()
                             {
                                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                 new Claim(ClaimTypes.Email, user.Email!),
                                 new Claim(ClaimTypes.Name, user.Name!),
                                 new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString()),
                                 new Claim("Operator", user.RolId.ToString()),
                             };

            if (user.Rol!.RolOperations.Count != 0)
            {
                claims.AddRange(user.Rol!.RolOperations.Select(item => new Claim(ClaimTypes.Role, item.IdOperation.ToString())));
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
