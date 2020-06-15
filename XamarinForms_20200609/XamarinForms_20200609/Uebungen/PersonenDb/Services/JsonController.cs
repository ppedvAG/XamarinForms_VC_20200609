﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinForms_20200609.Uebungen.PersonenDb.Services
{
    public static class JsonController
    {
        public static void Save(object data)
        {
            DependencyService.Get<IJsonService>().SaveJson(data);
        }

        public static T Load<T>()
        {
            return DependencyService.Get<IJsonService>().LoadJson<T>();
        }

    }
}
