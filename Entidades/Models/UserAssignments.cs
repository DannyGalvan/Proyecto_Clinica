using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserAssignments
    {
        public int    Id             { get; set; }
        public int    AssignedUserId { get; set; }
        public int    AssignerUserId { get; set; }
        public int    RequestId      { get; set; }
        public string CreatedAt      { get; set; } = string.Empty;

        public virtual User?    Assigned { get; set; }
        public virtual User?    Assigner { get; set; }
        public virtual Request? Request  { get; set; }
    }
}
