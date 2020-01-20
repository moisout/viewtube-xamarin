using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Toasts;
using Viewtube_Xamarin.Models;
using Viewtube_Xamarin.Services;
using Xamarin.Forms;

namespace Viewtube_Xamarin.ViewModels
{
    public class VideoDetailViewModel : BaseViewModel
    {
        public VideoElement VideoElement { get; set; }
        public Command LoadItemCommand { get; set; }

        VideoDetail videoDetail = new VideoDetail();
        public VideoDetail VideoDetail
        {
            get { return videoDetail; }
            set { SetProperty(ref videoDetail, value); }
        }

        public IVideoStore<VideoDetail> VideoDetailStore => DependencyService.Get<IVideoStore<VideoDetail>>();
        public VideoDetailViewModel(VideoElement video = null)
        {
            Title = video?.Title;
            VideoDetail = new VideoDetail();
            VideoElement = video;
            LoadItemCommand = new Command(async () => await ExecuteLoadItemCommand());
        }

        async Task ExecuteLoadItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                VideoDetail = await VideoDetailStore.GetItemAsync(VideoElement.VideoId, true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                var notificator = DependencyService.Get<IToastNotificator>();

                var options = new NotificationOptions()
                {
                    Title = "Error loading video",
                    Description = "API may be down"
                };

                var result = await notificator.Notify(options);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
