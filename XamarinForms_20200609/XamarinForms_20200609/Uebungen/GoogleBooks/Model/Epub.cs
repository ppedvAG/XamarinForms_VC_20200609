using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Model
{
    public partial class Epub
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("acsTokenLink", NullValueHandling = NullValueHandling.Ignore)]
        public string AcsTokenLink { get; set; }
    }
}

