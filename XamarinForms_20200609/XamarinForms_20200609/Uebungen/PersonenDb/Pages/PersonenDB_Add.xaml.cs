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
        public PersonenDB_Add()
        {
            InitializeComponent();

            Entry_Vorname.Completed += (s, e) => Entry_Nachname.Focus();
            Entry_Nachname.Completed += Btn_AddPerson_Clicked;
            Entry_Nachname.Completed += (s, e) => Entry_Vorname.Focus();
        }

        private void Btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            Person person = new Person()
            {
                Nachname = Entry_Nachname.Text,
                Vorname = Entry_Vorname.Text
            };

            StaticObjects.PersonenListe.Add(person);
            App.PersonenDatenbank.AddPerson(person);

            ToastController.ShowToastMessage("Person hinzugefügt", ToastDuration.Short);

            Entry_Vorname.Text = string.Empty;
            Entry_Nachname.Text = string.Empty;

        }
    }
}