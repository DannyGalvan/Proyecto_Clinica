using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Departments : Catalogue
    {
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
