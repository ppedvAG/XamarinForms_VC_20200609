using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace XamarinForms_20200609
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MC_SubscriberPage : ContentPage
    {
        //vgl. auch MainPage.xaml
        public MC_SubscriberPage()
        {
            InitializeComponent();

            //Abonieren einer Nachricht über das MessagingCenter unter Angabe von 
            //<Sender, Nachrichtentyp>(Empfänger, Titel, Methode zum Handeln des Inhalts)
            MessagingCenter.Subscribe<MainPage, string>(this, "GesendeterText", SetzeText);
        }

        //Methode, welche die MC-Nachricht handelt. Diese wird automatisch ausgeführt, wenn die Nachricht eintrifft
        private void SetzeText(object sender, string text)
        {
            Lbl_Main.Text = text;
        }

        //private async void Btn_Cam_Clicked(object sender, EventArgs e)
        //{
        //    if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //    {
        //        await DisplayAlert("Keine Kamera", "Kamera kann nicht benutzt werden", "OK");

        //        return;
        //    }

        //    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { Directory = "Sample", Name = "test.jpg" });

        //    if (file == null) return;

        //    await DisplayAlert("Foto geschossen", $"Gespeichert unter {file.Path}", "OK");

        //    Img_Cam.Source = ImageSource.FromStream(() =>
        //    {
        //        var stream = file.GetStream();
        //        file.Dispose();
        //        return stream;
        //    });
        //}
    }
}