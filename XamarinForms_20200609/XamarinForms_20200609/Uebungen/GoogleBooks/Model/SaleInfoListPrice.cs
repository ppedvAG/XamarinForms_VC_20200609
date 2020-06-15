
using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Model
{
    public partial class SaleInfoListPrice
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currencyCode")]
        public CurrencyCode CurrencyCode { get; set; }
    }
}

