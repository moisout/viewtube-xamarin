using System;
using Newtonsoft.Json;

namespace Viewtube_Xamarin.Models
{
    public class FormatStream
    {
        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("qualityLabel")]
        public string QualityText { get; set; }
    }
}