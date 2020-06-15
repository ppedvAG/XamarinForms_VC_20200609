using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinForms_20200609.BspMVVM.Model;
using XamarinForms_20200609.BspMVVM.Service;

namespace XamarinForms_20200609.BspMVVM.ViewModel
{
    //Das ViewModel dient als Verbindungsklasse zwischen einem View und den Model- und Controllerklassen.
    //Mittels des INotifyPropertyChanged-Interfaces kann das View über Property-Veränderungen informiert werden.
    public class MainViewModel : INotifyPropertyChanged
    {
        //Datenbank-Service
        public DbService Datenbank { get; set; }
        //zugehöriges View (zum Zugriff auf Page-Methoden wie z.B. DisplayAlert)
        public Page ContextPage { get; set; }

        //Properties zum Anbinden an das View (.NET-Properties benötigen bei Veränderung  einen Eventwurf, um das View 
        //über die Veränderung zu informieren
        public string NeuerVorname { get; set; }
        public string NeuerNachname { get; set; }
        private ObservableCollection<Person> personenListe;
        public ObservableCollection<Person> PersonenListe
        {
            get { return personenListe; }
            set
            {
                personenListe = value;
                //Aufruf des PropertyChanged-Events um das View über die Veränderung zu informieren
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonenListe)));
            }
        }
        public bool IsRefreshing { get; set; }

        //Command-Properties werden benötigt, um Eventwürfe auf EventHandler umzuleiten
        public Command RefreshCmd { get; set; }
        public Command HinzufuegenCmd { get; set; }
        public Command LoeschenCmd { get; set; }

        //Konstruktor
        public MainViewModel()
        {
            //Property-Initialisierungen
            this.Datenbank = new DbService();
            this.PersonenListe = new ObservableCollection<Person>();

            //Initialisierung der Command-Objekte mit Übergabe des auszuführenden EventHandlers
            this.HinzufuegenCmd = new Command(AddPerson);
            this.LoeschenCmd = new Command(DeletePerson);
            this.RefreshCmd = new Command(Refresh);

            //Aktualisierung der GUI
            Refresh();
        }

        //Durch das Interface gefordertes Event
        public event PropertyChangedEventHandler PropertyChanged;


        //EventHandler-Methoden
        public void AddPerson()
        {
            //Erstellen und Hinzufügen einer neuen Person
            Person neuePerson = new Person()
            {
                Vorname = NeuerVorname,
                Nachname = NeuerNachname
            };
            PersonenListe.Add(neuePerson);
            Datenbank.AddPerson(neuePerson);

            //Leeren der UI-Elemente
            NeuerNachname = string.Empty;
            NeuerVorname = string.Empty;
            //Informieren das Views über Veränderung in den Properties
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuerNachname)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuerVorname)));

            Refresh();
        }

        public async void DeletePerson(object p)
        {
            //Aufruf einer 'MessageBox' und Abfrage der User-Antwort über ContextPage-Property
            bool result = await ContextPage.DisplayAlert("Löschen", "Soll die Persomn wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                Datenbank.DeletePerson(p as Person);
                PersonenListe.Remove(p as Person);

                Refresh();
            }
        }

        //Methode zur Aktualisierung des ListViews
        private void Refresh()
        {
            PersonenListe = new ObservableCollection<Person>(Datenbank.GetPeople());
            IsRefreshing = false;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonenListe)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
        }
    }
}
