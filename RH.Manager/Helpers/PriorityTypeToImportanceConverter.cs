using System;
using System.Globalization;
using System.Windows.Data;
using Telerik.Windows.Controls.ScheduleView;

namespace RH.Manager
{
    public class PriorityTypeToImportanceConverter: IValueConverter
    {
        public static readonly PriorityTypeToImportanceConverter Instance = new PriorityTypeToImportanceConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (PriorityType)value;
            switch (priority)
            {
                case PriorityType.Low:
                    return Importance.Low;
                case PriorityType.Medium:
                    return Importance.None;
                case PriorityType.High:
                    return Importance.High;
                default:
                    throw new ArgumentException("Invalid priority value to convert!");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var importance = (Importance)value;
            switch (importance)
            {
                case Importance.None:
                    return PriorityType.Medium;
                case Importance.Low:
                    return PriorityType.Low;
                case Importance.High:
                    return PriorityType.High;
                default:
                    throw new ArgumentException("Invalid importance value to convert!");
            }
        }
    }
}
