
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public int IdModule { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual Module? Modulo { get; set; }
        public virtual ICollection<RolOperation> RolOperations { get; } = new List<RolOperation>();
    }
}
