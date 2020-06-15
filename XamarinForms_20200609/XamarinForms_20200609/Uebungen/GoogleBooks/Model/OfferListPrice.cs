
using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Model
{
    public partial class OfferListPrice
    {
        [JsonProperty("amountInMicros")]
        public long AmountInMicros { get; set; }

        [JsonProperty("currencyCode")]
        public CurrencyCode CurrencyCode { get; set; }
    }
}

