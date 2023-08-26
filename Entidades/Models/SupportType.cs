using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SupportType : Catalogue
    {
        public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    }
}
