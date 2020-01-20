using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Viewtube_Xamarin.Models;
using Viewtube_Xamarin.ViewModels;

namespace Viewtube_Xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        VideoDetailViewModel viewModel;

        public ItemDetailPage(VideoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            //viewModel = new ItemDetailViewModel(item);
            //BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.VideoElement != null)
                viewModel.LoadItemCommand.Execute(null);
        }
    }
}