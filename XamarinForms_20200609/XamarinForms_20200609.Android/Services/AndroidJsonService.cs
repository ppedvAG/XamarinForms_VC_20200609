using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinForms_20200609.Uebungen.PersonenDb.Services;

using Newtonsoft.Json;

//vgl. AndroidDatabaseService.cs
[assembly: Xamarin.Forms.Dependency(typeof(XamarinForms_20200609.Droid.Services.AndroidJsonService))]
namespace XamarinForms_20200609.Droid.Services
{
    class AndroidJsonService : IJsonService
    {
        private static string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "jsonfile.txt");

        public T LoadJson<T>()
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();

            string jsonString = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public void SaveJson(object data)
        {
            string jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
    }
}