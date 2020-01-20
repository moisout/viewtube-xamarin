using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Viewtube_Xamarin.Models;

namespace Viewtube_Xamarin.Services
{
    public class VideoDetailStore : IVideoStore<VideoDetail>
    {
        readonly VideoDetail videoDetail;

        public VideoDetailStore()
        {
            videoDetail = new VideoDetail();
        }

        public async Task<VideoDetail> GetItemAsync(string videoId, bool forceRefresh = false)
        {
            WebRequest request = WebRequest.Create($"{Invidious.ApiUrl}/api/v1/videos/{videoId}");

            WebResponse response = await request.GetResponseAsync();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = await reader.ReadToEndAsync();

            VideoDetail video = JsonConvert.DeserializeObject<VideoDetail>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return await Task.FromResult(video);
        }
    }
}