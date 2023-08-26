
namespace Entities.Models
{
    public class RolOperation
    {
        public         int        Id          { get; set; }
        public         int        RolId       { get; set; }
        public         int        OperationId { get; set; }
        public         string     CreatedAt   { get; set; } = string.Empty;
        public virtual Rol?       Rol         { get; set; }
        public virtual Operation? Operation   { get; set; }
    }
}
