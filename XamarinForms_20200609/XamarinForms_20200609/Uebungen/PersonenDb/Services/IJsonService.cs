using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Services
{
    //vgl. IDatabaseService
    //vgl. Android/Services/AndroidJsonService
    public interface IJsonService
    {
        void SaveJson(object data);

        T LoadJson<T>();
    }
}
