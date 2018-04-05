using RH.DataModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace RH.Manager
{
    public class ScheduleViewCustomDialogHost : ScheduleViewDialogBase, IScheduleViewDialogHost
    {
        public IEnumerable<Actividade> ActividadesDeisponibles
        {
            get
            {
                return (IEnumerable<Actividade>)GetValue(ActividadesDeisponiblesProperty);
            }
            set
            {
                SetValue(ActividadesDeisponiblesProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for AvailableActividades.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActividadesDeisponiblesProperty =
        DependencyProperty.Register("ActividadesDeisponibles", typeof(IEnumerable<Actividade>), typeof(ScheduleViewCustomDialogHost), new PropertyMetadata(null));

        public ScheduleViewCustomDialogHost()
        {
            SaveCommand = new DelegateCommand(OnSaveCommandExecuted);
            CancelCommand = new DelegateCommand(OnCancelCommandExecuted);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public void Close()
        {
            UnhookToViewModelPropertyChanged();

            Visibility = Visibility.Collapsed;

            Closed?.Invoke(this, new WindowClosedEventArgs());
        }

        private void OnSaveCommandExecuted(object parameter)
        {
            ScheduleView.Commit();
            
            Close();
        }

        private void OnCancelCommandExecuted(object parameter)
        {
            ScheduleView.Cancel();

            Close();
        }

        public event EventHandler<WindowClosedEventArgs> Closed;

        public ScheduleViewBase ScheduleView { get; set; }

        public void Show(bool isModal)
        {
            HookToViewModelPropertyChanged();
            
            Visibility = Visibility.Visible;
        }
  
        private void HookToViewModelPropertyChanged()
        {
            var viewModel = DataContext as AppointmentDialogViewModel;

            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void UnhookToViewModelPropertyChanged()
        {
            var viewModel =DataContext as AppointmentDialogViewModel;

            viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }

        void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var viewModel = sender as AppointmentDialogViewModel;
            
            if (viewModel.ActualStart > viewModel.ActualEnd)
            {
                viewModel.ActualEnd = viewModel.ActualStart.AddHours(1);
            }
        }
    }
}