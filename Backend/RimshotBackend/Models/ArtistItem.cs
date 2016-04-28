using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RimshotBackend.Models
{
    public class ArtistItem
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        public string Songkick { get; set; }
        public string Groove { get; set; }
        public string Spotify { get; set; }
       
        public bool IsDirty { get; set; }
    }
}