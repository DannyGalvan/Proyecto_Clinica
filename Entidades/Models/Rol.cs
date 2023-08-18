using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get;                     set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public virtual ICollection<RolOperation> RolOperations { get; set; } = new List<RolOperation>();
    }
}
