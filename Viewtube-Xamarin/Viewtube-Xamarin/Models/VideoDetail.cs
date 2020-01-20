using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Viewtube_Xamarin.Models
{
    public class VideoDetail
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }

        [JsonProperty("videoThumbnails")]
        public List<Thumbnail> VideoThumbnails { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lengthSeconds")]
        public int LengthSeconds { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        [JsonProperty("authorUrl")]
        public string AuthorUrl { get; set; }

        [JsonProperty("published")]
        public int Published { get; set; }

        [JsonProperty("publishedText")]
        public string PublishedText { get; set; }

        [JsonProperty("viewCount")]
        public int ViewCount { get; set; }

        [JsonProperty("formatStreams")]
        public List<FormatStream> FormatStreams { get; set; }

        public string ViewCountText { get
            {
                string viewString = "views";
                if(ViewCount == 1)
                {
                    viewString = "view";
                }
                return $"{ViewCount.ToString("N0")} {viewString}";
            } 
        }

    }
}