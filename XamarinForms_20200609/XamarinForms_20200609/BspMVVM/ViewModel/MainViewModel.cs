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
    public class MainViewModel : INotifyPropertyChanged
    {
        public DbService Datenbank { get; set; }
        public Page ContextPage { get; set; }

        public MainViewModel()
        {
            this.Datenbank = new DbService();

            this.PersonenListe = new ObservableCollection<Person>();

            this.HinzufuegenCmd = new Command(AddPerson);

            this.LoeschenCmd = new Command(DeletePerson);

            this.RefreshCmd = new Command(Refresh);

            Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddPerson()
        {
            Person neuePerson = new Person()
            {
                Vorname = NeuerVorname,
                Nachname = NeuerNachname
            };

            PersonenListe.Add(neuePerson);

            Datenbank.AddPerson(neuePerson);

            NeuerNachname = string.Empty;
            NeuerVorname = string.Empty;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuerNachname)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuerVorname)));

            Refresh();
        }

        public async void DeletePerson(object p)
        {
            bool result = await ContextPage.DisplayAlert("Löschen", "Soll die Persomn wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                Datenbank.DeletePerson(p as Person);
                PersonenListe.Remove(p as Person);

                Refresh();
            }
        }

        public string NeuerVorname { get; set; }
        public string NeuerNachname { get; set; }

        private ObservableCollection<Person> personenListe;
        public ObservableCollection<Person> PersonenListe
        {
            get { return personenListe; }
            set
            {
                personenListe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonenListe)));
            }
        }

        public Command HinzufuegenCmd { get; set; }
        public Command LoeschenCmd { get; set; }

        public bool IsRefreshing { get; set; }
        public Command RefreshCmd { get; set; }

        private void Refresh()
        {
            PersonenListe = new ObservableCollection<Person>(Datenbank.GetPeople());
            IsRefreshing = false;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonenListe)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
        }
    }
}
