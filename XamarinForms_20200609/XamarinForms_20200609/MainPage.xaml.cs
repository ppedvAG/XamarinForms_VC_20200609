using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms_20200609
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<string> PersonenListe { get; set; }

        public MainPage()
        {
            InitializeComponent();

            PersonenListe = new List<string>();
            PersonenListe.Add("Rainer Zufall");
            PersonenListe.Add("Anna Nass");

            LstV_Personen.ItemsSource = PersonenListe;

            Entry_FirstName.Completed += (s, e) => Entry_LastName.Focus();
            Entry_LastName.Completed += Btn_OK_Clicked;

            //Resource.Culture = new System.Globalization.CultureInfo("de");

            Lbl_Loc.Text = Resource.Lbl_String;
            Btn_Loc.Text = Resource.Btn_String;
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hallo Welt", "Moin Moin", "OK", "Abbrechen");

            Lbl_Eins.Text = "Ahoi";
        }

        private void Btn_OK_Clicked(object sender, EventArgs e)
        {
            string neuePerson = Entry_FirstName.Text + " " + Entry_LastName.Text;
            PersonenListe.Add(neuePerson);

            LstV_Personen.ItemsSource = null;
            LstV_Personen.ItemsSource = PersonenListe;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            PersonenListe.Clear();

            LstV_Personen.ItemsSource = null;
            LstV_Personen.ItemsSource = PersonenListe;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Löschen", "Möchten sie diesen Eintrag wirklich löschen?", "Ja", "Nein");

            if (result)
            {
                string person = (sender as MenuItem).CommandParameter.ToString();
                PersonenListe.Remove(person);

                LstV_Personen.ItemsSource = null;
                LstV_Personen.ItemsSource = PersonenListe;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Uebungen.StackLayoutUebung());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BspLayouts.CarouselNav());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BspLayouts.TabbedNav());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Page subscriber = new MC_SubscriberPage();

            MessagingCenter.Send(this, "GesendeterText", Entry_FirstName.Text);

            Navigation.PushAsync(subscriber);
        }
    }
}
