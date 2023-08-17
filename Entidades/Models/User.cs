using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public bool? Reset { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateToken { get; set; }
        [MaxLength(200)]
        public string? RecoveryToken { get; set; }
        [MaxLength(15)]
        public string? Number { get; set; }
        public int RolId { get; set; }
        public Rol? Rol { get; set; }
    }
}
