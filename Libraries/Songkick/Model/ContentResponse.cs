using Newtonsoft.Json;

namespace Songkick.Model
{
    public class ContentResponse
    {
        [JsonProperty("resultsPage")]
        public ResultsPage ResultsPage { get; set; }
    }
}
