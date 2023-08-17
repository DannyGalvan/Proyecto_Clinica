using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMail
    {
        public bool Send(string email, string affair, string message);
    }
}
