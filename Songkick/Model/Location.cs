using Newtonsoft.Json;

namespace Songkick.Model
{
    public class Location
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("metroArea")]
        public MetroArea MetroArea { get; set; }
    }
}
