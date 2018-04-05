using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RH.Manager.CustomControls
{
    public class EditingTextBox : TextBox
    {
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditingTextBox), new PropertyMetadata(false, OnIsInEditModePropertyChanged));

        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            this.EndEditMode();
        }

        private static void OnIsInEditModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var tBox = d as TextBox;
            bool isVisible = (bool)args.NewValue == true;
            if (isVisible)
            {
                tBox.Visibility = Visibility.Visible;
                tBox.Focus();
                tBox.SelectAll();
            }
            else
            {
                tBox.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Enter)
            {
                this.EndEditMode();
            }
        }

        private void EndEditMode()
        {
            BindingExpression expression = this.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
            this.IsInEditMode = false;
        }
    }
}
