using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Viewtube_Xamarin.Models;
using Viewtube_Xamarin.Views;
using Viewtube_Xamarin.ViewModels;

namespace Viewtube_Xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var video = args.SelectedItem as VideoElement;
            if (video == null)
            {
                ItemsListView.SelectedItem = null;
                return;
            }


            ItemDetailPage detailPage = new ItemDetailPage(new VideoDetailViewModel(video));
            ItemsListView.SelectedItem = null;
            await Navigation.PushAsync(detailPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Videos.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}