using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace RH.Manager.Converters
{
    public class NavigationIntervalStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = value.ToString();
            string[] strArr = str.Split(new string[]{"Start: ","End: ",", "},StringSplitOptions.RemoveEmptyEntries);

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            DateTime.TryParse(strArr[0],out start);
            DateTime.TryParse(strArr[1],out end);

            if (start.Date == end.Date)
            {
                return String.Empty;
            }
            return String.Format(" - {0:dd MMM yy}", end);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
