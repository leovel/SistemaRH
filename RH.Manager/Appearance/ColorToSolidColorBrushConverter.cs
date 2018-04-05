using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace RH.Manager.Appearance
{
    internal class ColorToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color? color = value as Color?;
            if (color == null)
            {
				return value;
            }

            return new SolidColorBrush(color.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}