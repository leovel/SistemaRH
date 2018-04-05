using System;
using System.Windows;
using System.Windows.Data;

namespace RH.Manager.Converters
{
    public class StatusToDataTemplateConverter : IValueConverter
    {
        private static readonly ResourceDictionary resourceDictionary;

        static StatusToDataTemplateConverter()
        {
            // assumes that a reference to RadGridView's assemblies have been loaded
            resourceDictionary = new ResourceDictionary() { Source = new Uri("/CRM.Theme;component/Styles/RadGridViewStyle.xaml", UriKind.Relative) };
        }
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return resourceDictionary["ActivityNotStartedDataTemplate"] as DataTemplate;
            }

            switch (value.ToString())
            {
                case "0":
                    return resourceDictionary["ActivityNotStartedDataTemplate"] as DataTemplate;
                case "1":
                    return resourceDictionary["ActivityInProgressDataTemplate"] as DataTemplate;
                case "2":
                    return resourceDictionary["ActivityDoneDataTemplate"] as DataTemplate;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}