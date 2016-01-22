using Newtonsoft.Json;

namespace Songkick.Model
{
    public class MetroArea : Content
    {
        [JsonProperty("lat")]
        public float? Latitude { get; set; }

        [JsonProperty("lng")]
        public float? Longitude { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
