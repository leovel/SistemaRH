using RH.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RH.Manager.Converters
{
    public class ShapeBackgroundSelector : IValueConverter
    {
        public Brush DireccaoBrush
        {
            get;
            set;
        }

        public Brush DepartamentoBrush
        {
            get;
            set;
        }

        public Brush SeccaoBrush
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AreaDeTrabalho area = (AreaDeTrabalho)value;
            switch (area)
            {
                case Direccao dir:
                    return DireccaoBrush;
                case Departamento dep:
                    return DepartamentoBrush;
                case Seccao sec:
                    return SeccaoBrush;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
