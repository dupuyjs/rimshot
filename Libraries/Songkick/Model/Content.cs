using Newtonsoft.Json;

namespace Songkick.Model
{
    public abstract class Content
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
