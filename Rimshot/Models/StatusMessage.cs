using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rimshot.Models
{
    public class StatusMessage
    {
        public string Status
        {
            get; private set;
        }

        public StatusMessage(string status)
        {
            this.Status = status;
        }
    }
}
