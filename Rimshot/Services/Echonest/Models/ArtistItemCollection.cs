﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Echonest.Models;
using Newtonsoft.Json.Linq;

namespace Echonest.Models
{
    public static partial class ArtistItemCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<ArtistItem> DeserializeJson(JToken inputObject)
        {
            IList<ArtistItem> deserializedObject = new List<ArtistItem>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                ArtistItem artistItem = new ArtistItem();
                artistItem.DeserializeJson(iListValue);
                deserializedObject.Add(artistItem);
            }
            return deserializedObject;
        }
    }
}
