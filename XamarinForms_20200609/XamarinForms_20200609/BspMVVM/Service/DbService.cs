using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinForms_20200609.BspMVVM.Model;

namespace XamarinForms_20200609.BspMVVM.Service
{
    public class DbService
    {
        
        static object locker = new object();

        SQLiteConnection database;

        string pfad = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mvvm.db3");

        public DbService()
        {
            lock (locker)
            {
                database = new SQLiteConnection(pfad);

                database.CreateTable<Model.Person>();
            }
        }

        public Person GetPerson(Guid id)
        {
            lock (locker)
            {
                return database.Get<Person>(id);
            }
        }

        public List<Person> GetPeople()
        {
            lock (locker)
            {
                return database.Table<Person>().ToList();
            }
        }

        public int AddPerson(Person person)
        {
            lock (locker)
            {
                return database.Insert(person);
            }
        }

        public int UpdatePerson(Person person)
        {
            lock (locker)
            {
                return database.Update(person);
            }
        }

        public int DeletePerson(Person person)
        {
            lock (locker)
            {
                return database.Delete(person);
            }
        }

    }
}
