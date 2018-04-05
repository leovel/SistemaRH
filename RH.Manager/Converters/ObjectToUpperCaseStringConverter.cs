using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System;

namespace RH.Manager.Converters
{
    public class ObjectToUpperCaseStringConverter : IValueConverter
    {
        public static readonly ObjectToUpperCaseStringConverter Instance = new ObjectToUpperCaseStringConverter();

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return String.Empty;
            }
            string stringValue = value.ToString();
            string processedValue = Regex.Replace(stringValue, "([A-Z])", " $1").Trim().ToUpper();

            return processedValue;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string stringValue = value.ToString().Trim();
            string[] splittedValues = Regex.Split(stringValue, " ");
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < splittedValues.Length; i++)
            {
                char[] letters = splittedValues[i].ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                result.Append(letters);
            }
            return result.ToString();
        }
    }
}