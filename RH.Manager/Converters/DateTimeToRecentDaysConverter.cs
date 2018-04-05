using System;
using System.Windows.Data;

namespace RH.Manager.Converters
{
    public class DateTimeToRecentDaysConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }

            var date = (DateTime)value;

            TimeSpan difference = DateTime.Today - date.Date;
            	
            switch (difference.Days)
            {
                case 0:
                    return "TODAY";
                case 1:
                    return "YESTERDAY";
                case -1:
                    return "TOMORROW";
            }

            return date.ToString("MMMM dd, yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}