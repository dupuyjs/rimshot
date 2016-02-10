using Newtonsoft.Json;

namespace Songkick.Models
{
    public class Venue : Content
    {
        [JsonProperty("metroArea")]
        public MetroArea MetroArea { get; set; }

        [JsonProperty("lat")]
        public float? Latitude { get; set; }

        [JsonProperty("lng")]
        public float? Longitude { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("capacity")]
        public int? Capacity { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}