using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TraceabilityRequests
    {
        public int    Id              { get; set; }
        public int    RequestId       { get; set; }
        public int    StatusRequestId { get; set; }
        public string Observations   { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;

        public virtual Request?       Request { get; set; }
        public virtual RequestStatus? Status  { get; set; }
    }
}
