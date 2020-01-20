using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Viewtube_Xamarin.Models;

namespace Viewtube_Xamarin.Services
{
    public class PopularVideosStore : IVideosStore<VideoElement>
    {
        readonly List<VideoElement> items;

        public PopularVideosStore()
        {
            items = new List<VideoElement>();
        }

        public async Task<IEnumerable<VideoElement>> GetItemsAsync(bool forceRefresh = false)
        {
            WebRequest request = WebRequest.Create($"{Invidious.ApiUrl}/api/v1/popular");

            WebResponse response = await request.GetResponseAsync();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = await reader.ReadToEndAsync();

            List<VideoElement> videos = JsonConvert.DeserializeObject<List<VideoElement>>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return await Task.FromResult(videos);
        }
    }
}