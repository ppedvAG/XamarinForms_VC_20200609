using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Services
{
    //vgl. IDatabaseService
    //vgl. Android/Services/AndroidToastService
    public interface IToastService
    {
        void ShowLong(string msg);
        void ShowShort(string msg);
    }
}
