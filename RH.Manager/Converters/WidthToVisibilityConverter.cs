using System;
using System.Windows;
using System.Windows.Data;

namespace RH.Manager.Converters
{
    public class WidthToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Double actualWidth = (Double)value;
            return (actualWidth < 160d && actualWidth > 0d) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();           
        }
    }
}
