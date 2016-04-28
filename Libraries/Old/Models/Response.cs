using System;

namespace Echonest.Models
{
    public class Response
    {
        public Status status { get; set; }
        public int start { get; set; }
        public int total { get; set; }
        public Image[] images { get; set; }
        public Artist artist { get; set; }
        public Biography[] biographies { get; set; }
    }
}
