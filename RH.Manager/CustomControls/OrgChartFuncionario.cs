using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.DragDrop;

namespace RH.Manager.CustomControls
{
    public class OrgChartFuncionario : ListBoxItem
    {
        public static DependencyProperty ScaleLevelProperty =
            DependencyProperty.Register("ScaleLevel", typeof(double), typeof(OrgChartFuncionario), null);
        public static readonly DependencyProperty IsSettingsWheelVisibleProperty =
            DependencyProperty.Register("IsSettingsWheelVisible", typeof(bool), typeof(OrgChartFuncionario), new PropertyMetadata(false));
        public static readonly DependencyProperty IsButtonOpenProperty =
           DependencyProperty.Register("IsButtonOpen", typeof(bool), typeof(OrgChartFuncionario), new PropertyMetadata(false));


        static OrgChartFuncionario()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OrgChartFuncionario), new FrameworkPropertyMetadata(typeof(OrgChartFuncionario)));
        }

        protected override void OnPreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnPreviewMouseRightButtonDown(e);
            e.Handled = true;
        }

        public OrgChartFuncionario()
        {
            this.Loaded += this.OrgChartNodeMemberItem_Loaded;
            this.Unloaded += this.OrgChartNodeMemberItem_Unloaded;
        }

        public double ScaleLevel
        {
            get
            {
                return (double)this.GetValue(OrgChartFuncionario.ScaleLevelProperty);
            }
            set
            {
                this.SetValue(OrgChartFuncionario.ScaleLevelProperty, value);
            }
        }

        public bool IsSettingsWheelVisible
        {
            get
            {
                return (bool)GetValue(OrgChartFuncionario.IsSettingsWheelVisibleProperty);
            }
            set
            {
                SetValue(OrgChartFuncionario.IsSettingsWheelVisibleProperty, value);
            }
        }

        public bool IsButtonOpen
        {
            get { return (bool)GetValue(IsButtonOpenProperty); }
            set { SetValue(IsButtonOpenProperty, value); }
        }

        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            this.IsSettingsWheelVisible = true;
        }

        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {
            this.IsSettingsWheelVisible = false;
        }

        private void OrgChartNodeMemberItem_Loaded(object sender, RoutedEventArgs e)
        {
            DragDropManager.AddDragInitializeHandler(this, this.OnDragInitialized, true);
        }

        private void OrgChartNodeMemberItem_Unloaded(object sender, RoutedEventArgs e)
        {
            DragDropManager.RemoveDragInitializeHandler(this, this.OnDragInitialized);
        }

        private void OnDragInitialized(object sender, DragInitializeEventArgs e)
        {
            e.DragVisual = new OrgChartDragView() { DataContext = this.DataContext };
            e.DragVisualOffset = new Point(e.RelativeStartPoint.X * (1 - this.ScaleLevel), e.RelativeStartPoint.Y * (1 - this.ScaleLevel));
        }
    }
}
