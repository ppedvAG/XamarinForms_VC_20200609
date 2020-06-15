using System;
using System.Collections.Generic;

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Model
{

    public partial class GBook
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public enum AccessViewStatus { None, Sample };

    public enum Country { De };

    public enum TextToSpeechPermission { Allowed };

    public enum Viewability { No_Pages, Partial, All_Pages };

    public enum Kind { BooksVolume };

    public enum CurrencyCode { Eur };

    public enum Saleability { ForSale, NotForSale };

    public enum Language { De, En, Fr };

    public enum MaturityRating { NotMature };

    public enum PrintType { Book };

    public partial struct PublishedDate
    {
        public DateTimeOffset? DateTime;
        public long? Integer;

        public bool IsNull => DateTime == null && Integer == null;
    }  
}

