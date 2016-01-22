using Newtonsoft.Json;
using System.Collections.Generic;

namespace Songkick.Model
{
    public class Artist : Content
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("identifier")]
        public List<Identifier> Identifiers { get; set; }

        [JsonProperty("onTourUntil")]
        public string OnTourUntil { get; set; }
    } 
}
