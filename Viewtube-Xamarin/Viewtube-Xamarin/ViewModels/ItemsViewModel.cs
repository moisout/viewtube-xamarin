using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Viewtube_Xamarin.Models;
using Plugin.Toasts;

namespace Viewtube_Xamarin.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<VideoElement> Videos { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "ViewTube";
            Videos = new ObservableCollection<VideoElement>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Videos.Clear();
                var videos = await PopularVideosStore.GetItemsAsync(true);
                foreach (var video in videos)
                {
                    Videos.Add(video);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                var notificator = DependencyService.Get<IToastNotificator>();

                var options = new NotificationOptions()
                {
                    Title = "Error loading videos",
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