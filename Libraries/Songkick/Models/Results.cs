using Newtonsoft.Json;
using Songkick.Serialization;
using System.Collections.Generic;

namespace Songkick.Models
{
    public class Results
    {
        [JsonProperty("event")]
        public List<EventExt> Events { get; set; }

        [JsonProperty("location")]
        public List<Location> Locations { get; set; }

        [JsonProperty("artist")]
        public List<ArtistExt> Artists { get; set; }

        [JsonProperty("venue")]
        [JsonConverter(typeof(SingleOrArrayConverter<VenueExt>))]
        public List<VenueExt> Venues { get; set; }
    }
}











