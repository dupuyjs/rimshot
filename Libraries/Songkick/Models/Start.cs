using Newtonsoft.Json;
using System;

namespace Songkick.Models
{
    public class Start
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("datetime")]
        public DateTime? DateTime { get; set; }
    }
}
