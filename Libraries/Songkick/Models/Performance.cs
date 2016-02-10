using Newtonsoft.Json;

namespace Songkick.Models
{
    public class Performance : Content
    {
        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("billingIndex")]
        public int? BillingIndex { get; set; }

        [JsonProperty("billing")]
        public string Billing { get; set; }
    }
}
