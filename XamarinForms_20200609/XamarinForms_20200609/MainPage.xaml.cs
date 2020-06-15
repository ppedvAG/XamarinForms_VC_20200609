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
        //Property zum Zwischenspeichern der Personenliste
        public List<string> PersonenListe { get; set; }

        //Konstruktor
        public MainPage()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //initialisierung der Personenliste
            PersonenListe = new List<string>();
            PersonenListe.Add("Rainer Zufall");
            PersonenListe.Add("Anna Nass");

            //Zuweisung der ItemSource des Listviews. Hierdurch werden die Elemente der Liste im ListView angezeigt und die Kutzbindungen
            //aus dem DataTemplate ermöglicht
            LstV_Personen.ItemsSource = PersonenListe;

            //Zuweisung von EventHandlern zu den Completet-Events, damit ein besserer Bedienfluss gegeben ist
            Entry_FirstName.Completed += (s, e) => Entry_LastName.Focus();
            Entry_LastName.Completed += Btn_OK_Clicked;

            //Neuzuordnung der verwendetet Culure (Sprache uä.)
            //Resource.Culture = new System.Globalization.CultureInfo("de");

            //Zuweisung von Sprachressourcen an UI-Elemente (vgl. Resource.resx und Resource.de.resx
            Lbl_Loc.Text = Resource.Lbl_String;
            Btn_Loc.Text = Resource.Btn_String;
        }

        //EventHandler
        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Anzeigen einer 'MessageBox'
            DisplayAlert("Hallo Welt", "Moin Moin", "OK", "Abbrechen");
            //Neuzuweisung einer UI-Property
            Lbl_Eins.Text = "Ahoi";
        }

        private void Btn_OK_Clicked(object sender, EventArgs e)
        {
            //Erstellen eines neuen Listenelements (aus UI-Properties)
            string neuePerson = Entry_FirstName.Text + " " + Entry_LastName.Text;
            PersonenListe.Add(neuePerson);

            //Aktualisieren der UI (insb. des ListViews)
            LstV_Personen.ItemsSource = null;
            LstV_Personen.ItemsSource = PersonenListe;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Löschen der Liste
            PersonenListe.Clear();

            //Aktualisieren der UI (insb. des ListViews)
            LstV_Personen.ItemsSource = null;
            LstV_Personen.ItemsSource = PersonenListe;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", "Möchten sie diesen Eintrag wirklich löschen?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                string person = (sender as MenuItem).CommandParameter.ToString();
                PersonenListe.Remove(person);

                //Aktualisieren der UI (insb. des ListViews)
                LstV_Personen.ItemsSource = null;
                LstV_Personen.ItemsSource = PersonenListe;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Uebungen.StackLayoutUebung());

            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keinen 'Zurück'-Button anzeigt
            //Navigation.PushModalAsync(new Uebungen.StackLayoutUebung());
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
            //Mittels des MessagingCenters können zwei voneinander unabhängige Objekte mittels eines Sender/Subscriber-Prinzips
            //miteinander kommunizieren

            //Instanziierung des Emfänger-Objekts (dieses muss zum Zeitpunkt der Nachricht-Sendes bereits existieren)
            Page subscriber = new MC_SubscriberPage();

            //Senden der Nachricht inkl. Sender, Titel und Inhalt
            MessagingCenter.Send(this, "GesendeterText", Entry_FirstName.Text);

            //Navigation zum Empfänger-Objekt (vgl. MC_SubscriberPage.xaml)
            Navigation.PushAsync(subscriber);
        }
    }
}
