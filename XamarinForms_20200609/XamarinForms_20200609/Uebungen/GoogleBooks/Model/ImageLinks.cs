
using Newtonsoft.Json;
using System.IO;
using Xamarin.Forms;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Model
{
    public partial class ImageLinks
    {
        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        public ImageSource GetSmallThumbnail
        {
            get { return ImageSource.FromUri(new System.Uri(SmallThumbnail)); }
        }
    }
}

