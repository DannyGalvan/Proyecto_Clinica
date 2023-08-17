using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Request
{
    public class CreateUserRequest
    {
        public string? Name { get; set; }     
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public bool? Reset { get; set; }
        public string? Number { get; set; }
        public int RolId { get; set; }
    }
}
