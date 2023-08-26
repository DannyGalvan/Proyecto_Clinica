using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public interface ICatalogue
    {
        public int     Id          { get; set; }
        public string  Name        { get; set; }
        public string  Description { get; set; }
        public string  CreatedAt   {get;  set; }
        public string? UpdatedAt   { get; set; }
        public int     CreatedBy   { get; set; }
        public int?    UpdatedBy   { get; set; }
        public User?   Creator     { get; set; }
        public User?   Updater     { get; set; }
    }
}
