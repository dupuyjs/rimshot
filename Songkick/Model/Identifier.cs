using Newtonsoft.Json;

namespace Songkick.Model
{
    public class Identifier
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("eventsHref")]
        public string EventsHref { get; set; }

        [JsonProperty("setlistsHref")]
        public string SetlistsHref { get; set; }
    }
}
