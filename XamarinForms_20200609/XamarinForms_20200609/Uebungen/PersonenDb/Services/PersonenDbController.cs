using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinForms_20200609.Uebungen.PersonenDb.Model;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Services
{
    public class PersonenDbController
    {
        static object locker = new object();

        SQLiteConnection database;

        public PersonenDbController()
        {
            lock (locker)
            {
                database = DependencyService.Get<IDatabaseService>().GetConnection();

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
