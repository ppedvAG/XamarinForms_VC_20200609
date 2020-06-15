using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Services
{
    public interface IToastService
    {
        void ShowLong(string msg);
        void ShowShort(string msg);
    }
}
