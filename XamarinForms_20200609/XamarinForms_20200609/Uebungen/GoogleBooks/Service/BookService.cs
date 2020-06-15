using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using XamarinForms_20200609.Uebungen.GoogleBooks.Model;

namespace XamarinForms_20200609.Uebungen.GoogleBooks.Service
{
    public class BookService
    {
        public GBook FindBooks(string searchstring)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                json = client.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={searchstring}");
            }

            return JsonConvert.DeserializeObject<GBook>(json);
        }
    }
}
