using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinForms_20200609.BspLayouts.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {
        public ListView ListView;

        public MDPMaster()
        {
            InitializeComponent();

            BindingContext = new MDPMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPMasterMenuItem> MenuItems { get; set; }

            public MDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPMasterMenuItem>(new[]
                {
                    new MDPMasterMenuItem { Id = 0, Title = "Startseite", TargetType=typeof(MainPage) },
                    new MDPMasterMenuItem { Id = 1, Title = "Tabbed Page", TargetType=typeof(TabbedNav) },
                    new MDPMasterMenuItem { Id = 2, Title = "Carousel Page", TargetType=typeof(CarouselNav) },
                    new MDPMasterMenuItem { Id = 3, Title = "PersonenDb", TargetType=typeof(Uebungen.PersonenDb.Navigation.MDP) },
                    new MDPMasterMenuItem { Id = 4, Title = "MVVMBsp", TargetType=typeof(BspMVVM.View.MainView) },
                    new MDPMasterMenuItem { Id = 5, Title = "GoogleBooks", TargetType=typeof(Uebungen.GoogleBooks.View.MainView) }
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