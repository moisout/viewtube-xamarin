using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Viewtube_Xamarin.Services;
using Viewtube_Xamarin.Views;

namespace Viewtube_Xamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<PopularVideosStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
