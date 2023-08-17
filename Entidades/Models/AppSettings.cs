using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppSettings
    {
        public string Secret           { get; set; } = string.Empty;
        public string Email            { get; set; } = string.Empty;
        public string EmailCredentials { get; set; } = string.Empty;
        public string MailForwarding { get; set; } = string.Empty;
    }
}
