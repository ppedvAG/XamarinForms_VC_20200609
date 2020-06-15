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
using SQLite;
using Xamarin.Forms;
using XamarinForms_20200609.Uebungen.PersonenDb.Services;

[assembly: Dependency(typeof(XamarinForms_20200609.Droid.Services.AndroidDatabaseService))]
namespace XamarinForms_20200609.Droid.Services
{
    class AndroidDatabaseService : IDatabaseService
    {
        public SQLiteConnection Con { get; set; }

        public SQLiteConnection GetConnection()
        {
            string ordner = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbName = "PersonenDb.db3";

            string path = Path.Combine(ordner, dbName);

            Con = new SQLiteConnection(path);

            return Con;
        }
    }
}