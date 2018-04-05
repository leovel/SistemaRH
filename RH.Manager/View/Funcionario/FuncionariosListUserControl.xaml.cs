using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace RH.Manager.View
{
    public partial class FuncionariosListUserControl : UserControl
    {
        public FuncionariosListUserControl()
        {
            InitializeComponent();
            this.gridView.SelectionChanged += this.OnGridViewSelectionChanged;
        }

        private void OnGridViewSelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            var grid = sender as RadGridView;
            if (grid.SelectedItem != null)
            {
                grid.ScrollIntoView(grid.SelectedItem);
            }
        }
    }
}
