using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Viewtube_Xamarin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Viewtube_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPageMaster : ContentPage
{
    public ListView ListView;

    public MainPageMaster()
    {
        InitializeComponent();

        BindingContext = new MainPageMasterViewModel();
        ListView = MenuItemsListView;
    }

    class MainPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainPageMasterMenuItem> MenuItems { get; set; }

        public string InstanceUrl
        {
          get { return $"Powered by {Invidious.ApiUrl}"; }
        }

        public string AuthorText
        {
          get { return "By Maurice Oegerli"; }
        }

        public MainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainPageMasterMenuItem>(new[]
            {
                    new MainPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MainPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MainPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MainPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MainPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
}