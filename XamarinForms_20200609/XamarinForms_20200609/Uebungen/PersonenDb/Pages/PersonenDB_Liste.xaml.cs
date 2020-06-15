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
            //GUI-Initialisierung
            InitializeComponent();

            //zuweisung der lokalen Liste mit den Datenbank-Inhalten
            StaticObjects.PersonenListe = App.PersonenDatenbank.GetPeople();

            //Aktualisieren der GUI
            RefreshPage();
        }

        //EventHandler zum Löschen einer Person
        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            //Cast des Inhalts der CommandParameter-Property des Sender-Objekts (das ausgewählte ListView-Item) in Person-Objekt
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", $"Soll {p.Vorname} {p.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen aus lokaler Liste
                StaticObjects.PersonenListe.Remove(p);
                //Löschen aus Datenbank
                App.PersonenDatenbank.DeletePerson(p);

                //Ausgabe einer Toast-Nachricht mittels ToastController
                ToastController.ShowToastMessage("Person gelöscht", ToastDuration.Short);
            }

            //Aktualisieren der GUI
            RefreshPage();

        }

        //Methode zum Aktualisieren der GUI
        private void RefreshPage()
        {
            //Setzen der veränderten Property auf null
            LstV_Liste.ItemsSource = null;
            //Neuzuweisung der veränderten Property
            LstV_Liste.ItemsSource = StaticObjects.PersonenListe;
        }

        //EventHandler zum Speichern der Liste (mittels Json)
        private void ToolbarItem_Save(object sender, EventArgs e)
        {
            //Aufruf der Save-Methode des JsonControllers
            JsonController.Save(StaticObjects.PersonenListe);
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste gespeichert", ToastDuration.Short);
        }

        //EventHandler zum Laden der Liste (mittels Json)
        private void ToolbarItem_Load(object sender, EventArgs e)
        {
            //Neuzuweisung der lokalen Liste mit durch JsonController geladenen Datei
            StaticObjects.PersonenListe = JsonController.Load<List<Person>>();
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste geladen", ToastDuration.Short);
            //Aktualisierung der GUI
            RefreshPage();
        }

        //EventHandler zum Leeren der Liste
        private void ToolbarItem_Clear(object sender, EventArgs e)
        {
            //Lokale Liste leeren
            StaticObjects.PersonenListe.Clear();
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste geräumt", ToastDuration.Short);
            //Aktualisierung der GUI
            RefreshPage();
        }
    }
}