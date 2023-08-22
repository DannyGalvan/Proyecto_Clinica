using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Client
    {
        public int    Id         { get; set; }
        public int    UserId     { get; set; }
        public string Nit        { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string Cui        { get; set; } = string.Empty;
        public string Name       { get; set; } = string.Empty;
        public string LastName   { get; set; } = string.Empty;
        public string Address    { get; set; } = string.Empty;
        public string Number     { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public virtual User? User { get; set; }
    }
}
