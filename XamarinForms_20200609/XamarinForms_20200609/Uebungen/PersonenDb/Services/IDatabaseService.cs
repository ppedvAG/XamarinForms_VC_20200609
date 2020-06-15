using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Services
{
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}
