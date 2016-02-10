using Newtonsoft.Json;
using System.Collections.Generic;

namespace Songkick.Models
{
    public class Event : Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("ageRestriction")]
        public string AgeRestriction { get; set; }

        [JsonProperty("performance")]
        public List<Performance> Performances { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("location")]
        public EventLocation Location { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("popularity")]
        public float? Popularity { get; set; }

        [JsonProperty("start")]
        public Start Start { get; set; }

        [JsonProperty("end")]
        public End End { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }
    }
}