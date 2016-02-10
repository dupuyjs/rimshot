using Newtonsoft.Json;

namespace Songkick.Models
{
    public class ContentResponse
    {
        [JsonProperty("resultsPage")]
        public ResultsPage ResultsPage { get; set; }
    }
}
