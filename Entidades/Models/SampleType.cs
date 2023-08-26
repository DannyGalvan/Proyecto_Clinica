using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SampleType : Catalogue
    {
        public virtual ICollection<Sample> Samples { get; set; } = new List<Sample>();
    }
}
