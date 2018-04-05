using System;
using System.Windows;
using System.Windows.Data;

namespace RH.Manager.Converters
{
    public class BooleanToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Double gridActualWidth = (Double)value;
            Double imageWidth = 108;

            return (gridActualWidth < 380 && gridActualWidth > 0d) ? 330 : Math.Max((Double)value, (gridActualWidth - imageWidth));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();           
        }
    }
}
