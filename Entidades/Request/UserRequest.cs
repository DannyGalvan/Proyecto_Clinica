

namespace Entities.Request
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }
        public string? Number { get; set; }
        public int RolId { get; set; }
    }
}
