using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Diagrams.Core;

namespace RH.Manager.Converters
{
    public class LayoutTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var layoutType = value as TreeLayoutType?;
            if (layoutType.HasValue)
            {
                switch (layoutType)
                {
                    case TreeLayoutType.TipOverTree: return Visibility.Visible;
                    default: return Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
