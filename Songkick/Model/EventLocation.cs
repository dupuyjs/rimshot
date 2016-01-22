using Newtonsoft.Json;

namespace Songkick.Model
{
    public class EventLocation
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("lat")]
        public float? Latitude { get; set; }

        [JsonProperty("lng")]
        public float? Longitude { get; set; }
    }
}
