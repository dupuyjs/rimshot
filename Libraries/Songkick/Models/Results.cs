using Newtonsoft.Json;
using System.Collections.Generic;

namespace Songkick.Models
{
    public class Results
    {
        [JsonProperty("event")]
        public List<Event> Events { get; set; }

        [JsonProperty("location")]
        public List<Location> Locations { get; set; }

        [JsonProperty("artist")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("venue")]
        public List<Venue> Venues { get; set; }
    }
}











