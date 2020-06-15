using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms_20200609.Uebungen.PersonenDb.Model;
using XamarinForms_20200609.Uebungen.PersonenDb.Services;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonenDB_Liste : ContentPage
    {
        public PersonenDB_Liste()
        {
            InitializeComponent();

            StaticObjects.PersonenListe = App.PersonenDatenbank.GetPeople();

            RefreshPage();
        }

        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            bool result = await DisplayAlert("Löschen", $"Soll {p.Vorname} {p.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                StaticObjects.PersonenListe.Remove(p);
                App.PersonenDatenbank.DeletePerson(p);

                ToastController.ShowToastMessage("Person gelöscht", ToastDuration.Short);
            }
            RefreshPage();

        }

        private void RefreshPage()
        {
            LstV_Liste.ItemsSource = null;
            LstV_Liste.ItemsSource = StaticObjects.PersonenListe;
        }

        private void ToolbarItem_Save(object sender, EventArgs e)
        {
            JsonController.Save(StaticObjects.PersonenListe);

            ToastController.ShowToastMessage("Liste gespeichert", ToastDuration.Short);
        }

        private void ToolbarItem_Load(object sender, EventArgs e)
        {
            StaticObjects.PersonenListe = JsonController.Load<List<Person>>();

            ToastController.ShowToastMessage("Liste geladen", ToastDuration.Short);

            RefreshPage();
        }

        private void ToolbarItem_Clear(object sender, EventArgs e)
        {
            StaticObjects.PersonenListe.Clear();

            ToastController.ShowToastMessage("Liste geräumt", ToastDuration.Short);

            RefreshPage();
        }
    }
}