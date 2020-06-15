using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Model
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        [Ignore]
        public string FullName
        {
            get { return $"{Vorname} {Nachname}"; }
        }
    }
}
