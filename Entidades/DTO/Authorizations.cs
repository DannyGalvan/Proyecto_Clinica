using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.DTO
{
    public class Authorizations
    {
        public Module?                Module     { get; set; }
        public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    }
}
