using System;
using System.Globalization;
using System.Windows.Data;
using Telerik.Windows.Controls.TransitionControl;

namespace RH.Manager.Converters
{	
	public class BooleanToTransitionConverter : IValueConverter
	{
		public TransitionProvider TransitionForward { get; set; }
		public TransitionProvider TransitionBackward { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool) || (bool)value)
			{
				return TransitionForward;
			}
			else
			{
				return TransitionBackward;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
