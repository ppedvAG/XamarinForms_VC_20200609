using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinForms_20200609.BspMVVM.Model
{
    //Die Model-Klassen defnieren die Business-Objekte der App
    //In MVVM beinhalten die Model-Klassen keine Referenzen außerhalb anderer Modelklassen.
    public class Person
    {
        //SQLlite-Property-Attribute (vgl. Uebungen/PersonenDb/Model)
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
