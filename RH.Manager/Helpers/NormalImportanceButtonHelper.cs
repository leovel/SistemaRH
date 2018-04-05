using System.Windows;
using System.Windows.Controls;

namespace RH.Manager
{
    public class NormalImportanceButtonHelper
    {
        private static void OnIsCheckedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as RadioButton;
            if ((bool)e.NewValue)
            {
                SetIsHighImportance(button, false);
                SetIsLowImportance(button, false);
            }
            else if (!GetIsLowImportance(button) && !GetIsHighImportance(button))
            {
                button.IsChecked = true;
            }
        }

        private static void OnIsHighImportancePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as RadioButton;
            button.IsChecked = !((bool)e.NewValue || GetIsLowImportance(button));
        }

        private static void OnIsLowImportancePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as RadioButton;
            button.IsChecked = !((bool)e.NewValue || GetIsHighImportance(button));
        }

        public static bool GetIsHighImportance(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHighImportanceProperty);
        }

        public static void SetIsHighImportance(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHighImportanceProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsHighImportance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHighImportanceProperty =
        DependencyProperty.RegisterAttached("IsHighImportance", typeof(bool), typeof(NormalImportanceButtonHelper), new PropertyMetadata(false, OnIsHighImportancePropertyChanged));

        public static bool GetIsLowImportance(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsLowImportanceProperty);
        }

        public static void SetIsLowImportance(DependencyObject obj, bool value)
        {
            obj.SetValue(IsLowImportanceProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsHighImportance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLowImportanceProperty =
        DependencyProperty.RegisterAttached("IsLowImportance", typeof(bool), typeof(NormalImportanceButtonHelper), new PropertyMetadata(false, OnIsLowImportancePropertyChanged));

        public static bool GetIsChecked(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCheckedProperty);
        }

        public static void SetIsChecked(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCheckedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.RegisterAttached("IsChecked", typeof(bool), typeof(NormalImportanceButtonHelper), new PropertyMetadata(true, OnIsCheckedPropertyChanged));
    }
}
