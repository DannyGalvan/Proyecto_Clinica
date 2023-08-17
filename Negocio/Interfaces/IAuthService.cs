using Entities.Request;
using Entities.Response;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        public Response<AuthResponse> Auth(LoginRequest model);
        public Response<string> ValidateToken(string token);
        public Response<string> ChangePassword(ChangePasswordRequest model);
        public Response<string> RecoveryPassword(RecoveryPasswordRequest model);
        public Response<string> ResetPassword(ResetPasswordRequest model);
    }
}
