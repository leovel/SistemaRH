using RH.DataModel;
using RH.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RH.Manager.Converters
{
    public class TreeViewItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AreaDeTrabalhoTemplate { get; set; }
        public DataTemplate FuncionarioTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is OrgAreaDeTrabalhoViewModel)
            {
                return AreaDeTrabalhoTemplate;
            }
            else if (item is OrgFuncionarioViewModel)
            {
                return FuncionarioTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
