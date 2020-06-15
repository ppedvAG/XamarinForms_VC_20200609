using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using XamarinForms_20200609.Uebungen.GoogleBooks.Model;

//Service-Klasse zum Zugriff auf GoogleBooks
namespace XamarinForms_20200609.Uebungen.GoogleBooks.Service
{
    public class BookService
    {
        public GBook FindBooks(string searchstring)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                //WebClient läd Bücherliste herunter
                json = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={searchstring}");
            }

            //Json deserialisiert den String in Model-Objekte
            return JsonConvert.DeserializeObject<GBook>(json);
        }
    }
}
