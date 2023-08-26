using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SamplesItem
    {
        public int    Id        { get; set; }
        public int    ItemId    { get; set; }
        public int    SampleId  { get; set; }
        public string CreatedAt { get; set; } = string.Empty;

        public virtual Item? Item { get; set; }
        public virtual Sample? Sample { get; set; }
    }
}
