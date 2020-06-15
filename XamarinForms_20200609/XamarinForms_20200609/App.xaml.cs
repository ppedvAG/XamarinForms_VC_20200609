using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_20200609.Uebungen.PersonenDb.Services;

namespace XamarinForms_20200609
{
    public partial class App : Application
    {
        private static PersonenDbController personenDatenbank;

        public static PersonenDbController PersonenDatenbank
        {
            get 
            {
                if (personenDatenbank == null)
                    personenDatenbank = new PersonenDbController();
                return personenDatenbank; 
            }
        }


        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());

            MainPage = new BspLayouts.MasterDetail.MDP();
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
