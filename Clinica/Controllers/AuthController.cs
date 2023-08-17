using Business.Interfaces;
using Business.Validations;
using Entities.Request;
using Entities.Response;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Response<AuthResponse>> Login([FromBody] LoginRequest model)
        {
            var validator = new LoginValidations();

            ValidationResult results = validator.Validate(model);

            if (!results.IsValid)
            {
                Response<List<ValidationFailure>> errors = new()
                {
                    Success = false,
                    Message = "Error al hacer la solicitud",
                    Data = results.Errors,
                };

                return BadRequest(errors);
            }

            Response<AuthResponse> response = _authService.Auth(model);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{token}")]
        public ActionResult<Response<string>> GetToken(string token)
        {
            Response<string> response = _authService.ValidateToken(token);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPut("ChangePassword")]
        public ActionResult<Response<string>> PutChangePassword([FromBody] ChangePasswordRequest model)
        {
            var validator = new ChangePasswordValidations();
            ValidationResult results = validator.Validate(model);

            if (!results.IsValid)
            {
                Response<List<ValidationFailure>> errors = new()
                {
                    Success = false,
                    Message = "Error al hacer la solicitud",
                    Data = results.Errors,
                };

                return BadRequest(errors);
            }

            Response<string> response = _authService.ChangePassword(model);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("ResetPassword")]
        public ActionResult<Response<string>> PostResetPassword([FromBody] ResetPasswordRequest model)
        {
            var validator = new ResetPasswordValidations();
            ValidationResult results = validator.Validate(model);

            if (!results.IsValid)
            {
                Response<List<ValidationFailure>> errors = new()
                {
                    Success = false,
                    Message = "Error al hacer la solicitud",
                    Data = results.Errors,
                };

                return BadRequest(errors);
            }

            Response<string> response = _authService.ResetPassword(model);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("RecoveryPassword")]
        public ActionResult<Response<string>> PostRecoveryPassword([FromBody] RecoveryPasswordRequest model)
        {
            var validator = new RecoveryPasswordValidations();
            ValidationResult results = validator.Validate(model);

            if (!results.IsValid)
            {
                Response<List<ValidationFailure>> errors = new()
                {
                    Success = false,
                    Message = "Error al hacer la solicitud",
                    Data = results.Errors,
                };

                return BadRequest(errors);
            }

            Response<string> oRespuesta = _authService.RecoveryPassword(model);

            return Ok(oRespuesta);
        }

    }

}
