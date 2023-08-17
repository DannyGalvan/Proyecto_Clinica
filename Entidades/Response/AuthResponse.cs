using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Response
{
    public class AuthResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public int Rol { get; set; }

        public ICollection<Authorizations> Operations { get; set; } = new List<Authorizations>();
    }
}
