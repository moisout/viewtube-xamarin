using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Viewtube_Xamarin.Models
{
    public class Thumbnail
    {
        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}