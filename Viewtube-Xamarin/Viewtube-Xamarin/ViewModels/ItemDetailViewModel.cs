using System;

using Viewtube_Xamarin.Models;

namespace Viewtube_Xamarin.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public VideoElement Video { get; set; }
        public ItemDetailViewModel(VideoElement video = null)
        {
            Title = video?.Title;
            Video = video;
        }
    }
}
