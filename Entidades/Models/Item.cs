using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Item : Catalogue
    {
        public virtual ICollection<SamplesItem> Items { get; set; } = new List<SamplesItem>();
    }
}
