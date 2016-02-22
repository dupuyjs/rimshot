﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Helpers.Extensions;
using System.ComponentModel;

namespace Songkick.Models
{
    public class Event : Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("ageRestriction")]
        public string AgeRestriction { get; set; }

        [JsonProperty("performance")]
        public List<Performance> Performances { get; set; }

        [JsonProperty("venue")]
        private VenueExt venue;
        public VenueExt Venue
        {
            get
            {
                return venue;
            }
            set
            {
                this.venue = value;
                OnPropertyChanged("Venue");
                OnPropertyChanged("Title");
                OnPropertyChanged("SubTitle");
            }
        }

        [JsonProperty("location")]
        public EventLocation Location { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("popularity")]
        public float? Popularity { get; set; }

        [JsonProperty("start")]
        public Start Start { get; set; }

        [JsonProperty("end")]
        public End End { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }
    }
}