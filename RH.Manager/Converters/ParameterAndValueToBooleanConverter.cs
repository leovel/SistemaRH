using System;
using System.Globalization;
using System.Windows.Data;

namespace RH.Manager.Converters
{
    public class ParameterAndValueToBooleanConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return parameter == null;
            }
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return parameter == null;
            }
            return value.Equals(parameter);
        }
    }
}
