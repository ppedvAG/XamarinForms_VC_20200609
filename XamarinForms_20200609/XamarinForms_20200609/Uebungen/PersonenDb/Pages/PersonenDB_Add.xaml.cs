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
    public partial class PersonenDB_Add : ContentPage
    {
        //Konstruktor
        public PersonenDB_Add()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Completed-EventHandler-Zuweisung (User-Komport)
            Entry_Vorname.Completed += (s, e) => Entry_Nachname.Focus();
            Entry_Nachname.Completed += Btn_AddPerson_Clicked;
            Entry_Nachname.Completed += (s, e) => Entry_Vorname.Focus();
        }

        //Methode zum Hinzufügen einer neuen Person
        private void Btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            //Objektinstanziierung mit User-Eingaben
            Person person = new Person()
            {
                Nachname = Entry_Nachname.Text,
                Vorname = Entry_Vorname.Text
            };

            //Hinzufügen zur lokalen Liste
            StaticObjects.PersonenListe.Add(person);
            //Hinzufügen zur Datenbank
            App.PersonenDatenbank.AddPerson(person);

            //Ausgabe eines Toasts über den ToastController
            ToastController.ShowToastMessage("Person hinzugefügt", ToastDuration.Short);

            //Leeren  der Eingabefelder
            Entry_Vorname.Text = string.Empty;
            Entry_Nachname.Text = string.Empty;

        }
    }
}