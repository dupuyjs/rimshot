using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echonest.Models
{
    public class Biography
    {
        public string text { get; set; }
        public string site { get; set; }
        public string url { get; set; }
        public License license { get; set; }
    }
}
