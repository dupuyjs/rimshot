using Newtonsoft.Json;

namespace Songkick.Models
{
    public class ResultsPage
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalEntries")]
        public string TotalEntries { get; set; }

        [JsonProperty("perPage")]
        public int PerPage { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public Results Results { get; set; }
    }
}
