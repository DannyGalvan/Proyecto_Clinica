
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Rol : Catalogue
    {
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public virtual ICollection<RolOperation> RolOperations { get; set; } = new List<RolOperation>();
    }
}
