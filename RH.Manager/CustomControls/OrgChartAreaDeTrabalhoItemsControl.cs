using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RH.Manager.CustomControls
{
    public class OrgChartAreaDeTrabalhoItemsControl : ListBox
    {

        static OrgChartAreaDeTrabalhoItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OrgChartAreaDeTrabalhoItemsControl), new FrameworkPropertyMetadata(typeof(OrgChartAreaDeTrabalhoItemsControl)));
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is OrgChartFuncionario;
        }

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new OrgChartFuncionario();
        }
    }
}
