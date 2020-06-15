using System;
using System.Collections.Generic;
using System.Text;
using XamarinForms_20200609.Uebungen.PersonenDb.Model;

namespace XamarinForms_20200609.Uebungen.PersonenDb
{
    //Statische Klasse mit globalen Objekten (kann auch Service- und Controllerobjekte beinhalten)
    public static class StaticObjects
    {
        private static List<Person> personenListe;
        public static List<Person> PersonenListe
        {
            get
            {
                if (personenListe == null)
                {
                    personenListe = new List<Model.Person>()
                    {
                        new Model.Person() { Vorname = "Rainer", Nachname = "Zufall" }
                    };
                }
                return personenListe;
            }
            set { personenListe = value; }
        }
    }
}
