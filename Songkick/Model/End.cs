using Newtonsoft.Json;
using System;

namespace Songkick.Model
{
    public class End
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("datetime")]
        public DateTime? DateTime { get; set; }
    }
}
