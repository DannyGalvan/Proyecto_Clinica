using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RolOperation
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdOperation { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Rol? Rol { get; set; }

        public virtual Operation? Operation { get; set; }
    }
}
