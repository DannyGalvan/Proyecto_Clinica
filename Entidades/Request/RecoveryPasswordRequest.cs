using System.ComponentModel.DataAnnotations;

namespace Entities.Request
{
    public class RecoveryPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
    }
}
