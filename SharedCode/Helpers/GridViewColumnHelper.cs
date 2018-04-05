using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace RH.Helpers
{
	public static class GridViewColumnHelper
	{
		public static bool GetIsGrouped(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsGroupedProperty);
		}

		public static void SetIsGrouped(DependencyObject obj, bool value)
		{
			obj.SetValue(IsGroupedProperty, value);
		}

		public static readonly DependencyProperty IsGroupedProperty =
            DependencyProperty.RegisterAttached("IsGrouped", typeof(bool), typeof(GridViewColumnHelper), new PropertyMetadata(false, OnIsGroupedChanged));

		private static void OnIsGroupedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			GridViewColumn column = sender as GridViewColumn;

			if (column.DataControl == null)
			{
				column.PropertyChanged += new PropertyChangedEventHandler(OnColumnPropertyChanged);
				return;
			}

			bool groupedState = (bool)args.NewValue;
			SetColumnGroupedState(column, groupedState);
		}

        public static bool GetIsImportant(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsImportantProperty);
        }

        public static void SetIsImportant(DependencyObject obj, bool value)
        {
            obj.SetValue(IsImportantProperty, value);
        }

        public static readonly DependencyProperty IsImportantProperty =
            DependencyProperty.RegisterAttached("IsImportant", typeof(bool), typeof(GridViewColumnHelper), new PropertyMetadata(false));

        private static void HideNonImportantColumns(RadGridView radGrid, bool hideNonImportantColumns)
        {
            foreach (var column in radGrid.Columns)
            {
                bool isImportant = (bool)column.GetValue(GridViewColumnHelper.IsImportantProperty);
                column.IsVisible = !hideNonImportantColumns | isImportant;
            }
        }

		static void OnColumnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			GridViewColumn column = sender as GridViewColumn;
			if (column.DataControl != null)
			{
				SetColumnGroupedState(column, true);
				column.PropertyChanged -= OnColumnPropertyChanged;
			}
		}

		private static void SetColumnGroupedState(GridViewColumn column, bool groupedState)
		{
			ColumnGroupDescriptor descriptor = (from d in column.DataControl.GroupDescriptors.OfType<ColumnGroupDescriptor>()
												where d.Column == column
												select d)
												.FirstOrDefault();
			if (groupedState && descriptor == null)
			{
                descriptor = new ColumnGroupDescriptor();
                descriptor.Column = column;
				column.DataControl.GroupDescriptors.Add(descriptor);
			}
			else if (!groupedState && descriptor != null)
			{
				column.DataControl.GroupDescriptors.Remove(descriptor);
			}
		}

        public static bool GetHideNonImportantColumns(DependencyObject obj)
		{
            return (bool)obj.GetValue(HideNonImportantColumnsProperty);
		}

        public static void SetHideNonImportantColumns(DependencyObject obj, bool value)
		{
            obj.SetValue(HideNonImportantColumnsProperty, value);
		}

        public static readonly DependencyProperty HideNonImportantColumnsProperty =
            DependencyProperty.RegisterAttached("HideNonImportantColumns", typeof(bool), typeof(GridViewColumnHelper), new PropertyMetadata(false, OnHideNonImportantColumnsChanged));

        private static void OnHideNonImportantColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
            var gridView = sender as RadGridView;
            if (gridView != null)
            {
                bool hideNonImportantColumns = (bool)args.NewValue;
                HideNonImportantColumns(gridView, hideNonImportantColumns);
            }
		}

        public static bool GetHideGroupedColumns(DependencyObject obj)
        {
            return (bool)obj.GetValue(HideGroupedColumnsProperty);
        }

        public static void SetHideGroupedColumns(DependencyObject obj, bool value)
        {
            obj.SetValue(HideGroupedColumnsProperty, value);
        }

        public static readonly DependencyProperty HideGroupedColumnsProperty =
            DependencyProperty.RegisterAttached("HideGroupedColumns", typeof(bool), typeof(GridViewColumnHelper), new PropertyMetadata(false, OnHideGroupedColumnsChanged));

        private static void OnHideGroupedColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            GridViewDataControl dataControl = sender as GridViewDataControl;
            bool newValue = (bool)args.NewValue;

            if (newValue)
            {
                foreach (ColumnGroupDescriptor descriptor in dataControl.GroupDescriptors)
                {
                    descriptor.Column.IsVisible = false;
                }

                dataControl.GroupDescriptors.CollectionChanged += OnGroupDescriptorCollectionChanged;
            }
            else
            {
                foreach (ColumnGroupDescriptor descriptor in dataControl.GroupDescriptors)
                {
                    descriptor.Column.IsVisible = true;
                }

                dataControl.GroupDescriptors.CollectionChanged -= OnGroupDescriptorCollectionChanged;
            }
        }

		private static void OnGroupDescriptorCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			ColumnGroupDescriptor descriptor = null;

			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				descriptor = e.NewItems[0] as ColumnGroupDescriptor;

				if (descriptor != null)
				{
					descriptor.Column.IsVisible = false;
				}
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				descriptor = e.OldItems[0] as ColumnGroupDescriptor;

				if (descriptor != null)
				{
					descriptor.Column.IsVisible = true;
				}
			}
		}
	}
}
