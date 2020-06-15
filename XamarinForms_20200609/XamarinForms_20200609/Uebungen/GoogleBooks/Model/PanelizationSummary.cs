
using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Model
{
    public partial class PanelizationSummary
    {
        [JsonProperty("containsEpubBubbles")]
        public bool ContainsEpubBubbles { get; set; }

        [JsonProperty("containsImageBubbles")]
        public bool ContainsImageBubbles { get; set; }
    }
}

