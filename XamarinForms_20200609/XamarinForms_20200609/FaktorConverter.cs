using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

//ValueConvreter werden verwendet um es XAML-Bindings zu ermöglichen Werte unterschiedlicher Typen zu verknüpfen oder die Werte vor der
//Übertragung zu manipulieren. Converter werden in den Resourcen definiert und in der Binding-Expression mit angegeben.
namespace XamarinForms_20200609
{
    public class FaktorConverter : IValueConverter
    {
        //(vgl. MainPage.xaml / Bereich: Bindings)

        //Source -> Target
        //Parameter: value = Wert aus der Quelle, targetType = Typ der Zielproperty, parameter = ConverterParameter-Property der Quelle)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Cast der Quellwerte
            double wert = System.Convert.ToDouble(value);
            double faktor = System.Convert.ToDouble(parameter);

            //Rückgabe des Produktes an Zielproperty
            return wert * faktor;
        }

        //Target->Source (in diesem bsp nicht nötig, da One-Wa-Bindung)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
